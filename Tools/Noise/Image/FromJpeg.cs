using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Noise.Mixer;

namespace Tools.Noise.Image
{
    public static class FromJpeg
    {
        public static byte[] DeriveKeyFromJpeg(string jpegPath, int keyLen)
        {
            // 1) Read bytes + timing jitter
            var sw = Stopwatch.StartNew();
            byte[] fileBytes = File.ReadAllBytes(jpegPath);
            sw.Stop();

            long ticks = sw.ElapsedTicks;

            // 2) Extract JPEG scan data if possible; fallback to full file bytes
            byte[] scan = TryExtractScanData(fileBytes, out var scanData)
                ? scanData
                : fileBytes;

            // 3) Mix scan bytes + timing into state
            uint state = 0xA5A5A5A5;               // non-zero init (not entropy)
            state = SimpleMixer.MixU64(state, (ulong)ticks);   // add a bit of timing jitter

            foreach (byte b in scan)
                state = SimpleMixer.MixByte(state, b);

            // 4) Expand into keyLen bytes
            return SimpleMixer.Expand(state, keyLen);
        }
        internal static bool TryExtractScanData(byte[] jpeg, out byte[] scanData)
        {
            scanData = Array.Empty<byte>();

            // Find SOS (FF DA)
            int sos = FindMarker(jpeg, 0xFF, 0xDA, 0);
            if (sos < 0 || sos + 4 >= jpeg.Length) return false;

            // big-endian length at sos+2..sos+3
            int sosLen = (jpeg[sos + 2] << 8) | jpeg[sos + 3];
            int scanStart = sos + 2 + sosLen;
            if (scanStart <= 0 || scanStart >= jpeg.Length) return false;

            // Find EOI (FF D9) robustly within scan data
            int eoi = FindEoiInScan(jpeg, scanStart);
            if (eoi < 0 || eoi <= scanStart) return false;

            int len = eoi - scanStart;
            scanData = new byte[len];
            Buffer.BlockCopy(jpeg, scanStart, scanData, 0, len);
            return true;
        }

        internal static int FindMarker(byte[] data, byte a, byte b, int start)
        {
            for (int i = start; i < data.Length - 1; i++)
                if (data[i] == a && data[i + 1] == b)
                    return i;
            return -1;
        }

        internal static int FindEoiInScan(byte[] data, int start)
        {
            // In scan data:
            // - FF 00 is stuffed literal FF
            // - FF D0..FF D7 are restart markers
            // - FF D9 is EOI
            for (int i = start; i < data.Length - 1; i++)
            {
                if (data[i] != 0xFF) continue;

                byte next = data[i + 1];

                if (next == 0x00) { i += 1; continue; }          // stuffed
                if (next == 0xD9) return i;                      // EOI
                if (next >= 0xD0 && next <= 0xD7) { i += 1; continue; } // restart
            }
            return -1;
        }
    }
}
