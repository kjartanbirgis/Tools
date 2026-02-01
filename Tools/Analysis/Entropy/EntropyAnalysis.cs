using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Analysis.Entropy
{
    public static class EntropyAnalysis
    {
        public static double OneRatio(byte[] data)
        {
            long ones = 0;
            foreach (byte b in data)
                ones += BitOperations.PopCount((uint)b);
            return ones / (8.0 * data.Length);
        }
        
        public static (double shannon, double minEnt, double chiSq) ByteStats(byte[] data)
        {
            long[] c = new long[256];
            foreach (byte b in data) c[b]++;

            double n = data.Length;
            double expected = n / 256.0;

            double shannon = 0.0;
            double maxP = 0.0;
            double chiSq = 0.0;

            for (int i = 0; i < 256; i++)
            {
                if (c[i] == 0) continue;

                double p = c[i] / n;
                shannon -= p * Math.Log(p, 2);

                if (p > maxP) maxP = p;

                double diff = c[i] - expected;
                chiSq += (diff * diff) / expected;
            }

            double minEnt = -Math.Log(maxP, 2);
            return (shannon, minEnt, chiSq);
        }
    }
}
