using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cryptography.Xor
{
    public static class OneTimePad
    {
        public static byte[] Encrypt(byte[] plaintext, byte[] key) => Xor(plaintext, key);
        public static byte[] Decrypt(byte[] ciphertext, byte[] key) => Xor(ciphertext, key);

        internal static byte[] Xor(byte[] data, byte[] key)
        {
            ArgumentNullException.ThrowIfNull(data);
            ArgumentNullException.ThrowIfNull(key); 
            if (key.Length != data.Length)
                throw new ArgumentException("The key must be the same length as data");
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^ key[i]);
            }
            return result;
        }
    }
}
