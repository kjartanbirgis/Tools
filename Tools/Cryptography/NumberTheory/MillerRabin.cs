using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cryptography.NumberTheory
{


    public static class MillerRabin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rounds"></param>
        /// <returns></returns>
        public static bool isProbablyPrime(BigInteger n, int rounds = 16)
        {
            if (n < 2)
            {
                return false;
            }
            if (n != 2 && n % 2 == 0)
            {
                return false;
            }

            int s = 0;
            BigInteger d = n - 1;
            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }
            Random rand = new Random();
            for (int i = 0; i < rounds; i++)
            {
                BigInteger a = RandomBigInteger(2, n - 2, rand);
                BigInteger x = BigInteger.ModPow(a, d, n);
                if (x == 1 || x == n - 1)
                    continue;
                bool continueOuter = false;
                for (BigInteger r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == n - 1)
                    {
                        continueOuter = true;
                        break;
                    }
                }
                if (continueOuter)
                    continue;
                return false;
            }
            return true;
        }
    }
}
