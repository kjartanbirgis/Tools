using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
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
            
            for (int i = 0; i < rounds; i++)
            {
                BigInteger a = RandomBetween(2, n - 2);
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
        
        /// <summary>
        /// Generates a cryptographically secure random BigInteger within the specified inclusive range.
        /// </summary>
        /// <param name="minInclusive">The inclusive lower bound of the random number to generate.</param>
        /// <param name="maxInclusive">The inclusive upper bound of the random number to generate.</param>
        /// <returns>A random BigInteger greater than or equal to minInclusive and less than or equal to maxInclusive.</returns>
        /// <exception cref="ArgumentException">Thrown when minInclusive is greater than maxInclusive.</exception>
        
        private static BigInteger RandomBetween(BigInteger minInclusive, BigInteger maxInclusive)
        {
            if (minInclusive > maxInclusive) throw new ArgumentException("min > max");

            BigInteger range = maxInclusive - minInclusive + 1;
            int bytes = range.GetByteCount(isUnsigned: true);

            while (true)
            {
                byte[] buf = RandomNumberGenerator.GetBytes(bytes);
                BigInteger x = new BigInteger(buf, isUnsigned: true, isBigEndian: false);
                if (x < range)
                    return minInclusive + x;
            }
        }
    }
}
