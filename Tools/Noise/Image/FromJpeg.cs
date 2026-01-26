using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Noise.Image
{
    public class FromJpeg
    {
        public static bool TryExtractScanData(byte[] jpeg, out byte[] scanData)
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

        private static int FindMarker(byte[] data, byte a, byte b, int start)
        {
            for (int i = start; i < data.Length - 1; i++)
                if (data[i] == a && data[i + 1] == b)
                    return i;
            return -1;
        }

        private static int FindEoiInScan(byte[] data, int start)
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
