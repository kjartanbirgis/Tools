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
        /// <summary>
        /// Combines a 32-bit unsigned integer with a byte using XOR, bit rotation, and multiplication for mixing
        /// purposes.
        /// </summary>
        /// <param name="s">The 32-bit unsigned integer to be mixed.</param>
        /// <param name="b">The byte value to mix into the integer.</param>
        /// <returns>The mixed 32-bit unsigned integer result.</returns>
        internal static uint MixByte(uint s, byte b)
        {
            s ^= b; //xor-að s við b
            s = RotL(s, 5); //rotate left um 5 bita bua til avalance
            s *= MixByteMIX1; //margföldum s með prime tölu til að auka dreifingu
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


        internal static uint RotL(uint x, int r)
        {
            r &= 31; //Gera r að vera innan 0-31
            return (x << r) | (x >> (32 - r)); //Rotate left með því að shift-a x til vinstri og hægri 32-r og OR-a saman
        }

        internal static byte[] Expand(uint seed, int outLen)
        {
            byte[] outp = new byte[outLen];
            uint x = seed;

            for (int i = 0; i < outLen; i++)
            {
                // a little diffusion each byte
                x ^= x >> 16; //x er xorað x sem er búið að shifttast 16 bitum til hægri |000000000|xxxxxxxx|
                x *= ExpandMIX1; //x margfaldað með fasta
                x ^= x >> 15; //shiftum 15 bitum til hægri og xor-að við x |0000000x|xxxxxxxx|
                x *= ExpandMIX2; //Margfölum x með öðrum fasta
                x ^= x >> 16; //shiftum 16 bitum til hægri og xor-að við x |000000000|xxxxxxxx|

                outp[i] = (byte)(x & 0xFF); //tökum lægstu 8 bita af x og setjum í array
            }

            return outp;
        }
    }
}
