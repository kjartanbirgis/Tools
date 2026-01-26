using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Noise.Mixer
{
    static internal class SimpleMixer
    {
        private const uint ExpandMIX1 = 0x7FEB352Du;
        private const uint ExpandMIX2 = 0x846CA68Bu;
        private const uint MixByteMIX1 = 0x9E3779B1u;

        internal static uint MixByte(uint s, byte b)
        {
            s ^= b;
            s = RotL(s, 5);
            s *= MixByteMIX1;
            return s;
        }

        internal static uint MixU64(uint s, ulong x)
        {
            for (int i = 0; i < 8; i++)
            {
                s = MixByte(s, (byte)(x & 0xFF));
                x >>= 8;
            }
            return s;
        }

        internal static uint RotL(uint x, int r) => (x << r) | (x >> (32 - r));

        internal static byte[] Expand(uint seed, int outLen)
        {
            byte[] outp = new byte[outLen];
            uint x = seed;

            for (int i = 0; i < outLen; i++)
            {
                // a little diffusion each byte
                x ^= x >> 16;
                x *= ExpandMIX1;
                x ^= x >> 15;
                x *= ExpandMIX2;
                x ^= x >> 16;

                outp[i] = (byte)(x & 0xFF);
            }

            return outp;
        }
    }
}
