using Tools.TextAnalysis.Language;

namespace Tools.Cryptography.Substition
{
    static public class Ceasar
    {
        /// <summary>
        /// Encrypts the specified text using a Caesar cipher with the given shift and alphabet type.
        /// </summary>
        /// <param name="Text">The text to encrypt. Cannot be <see langword="null"/>.</param>
        /// <param name="shift">The number of positions to shift each character in the text. Positive values shift forward; negative values
        /// shift backward.</param>
        /// <param name="AlphabetType">The alphabet type to use for the cipher. Determines which characters are affected by the shift.</param>
        /// <returns>A string containing the encrypted text. The format and characters depend on the specified 
        /// .</returns>
        public static string Encrypt(string Text, int shift, AlphabetType alphabetType, bool caseInsensitve = true)
        {
            if (Text == null)
            {
                throw new ArgumentNullException("Text may not be null");
            }
            if (caseInsensitve)
            {
                Text = Text.ToLower();
            }
            else
            {
                throw new NotImplementedException("Case sensitive encryption is not implemented yet");
            }
            string EncryptedText = string.Empty;
            char[] alphabet = Alphabets.GetAlphabet(alphabetType);
            for (int i = 0; i < Text.Length; i++)
            {
                char c = Text[i];
                if (alphabet.Contains(c))
                {
                    int index = Array.IndexOf(alphabet, c);
                    int shiftedIndex = (index + shift) % alphabet.Length;
                    if (shiftedIndex < 0)
                    {
                        shiftedIndex += alphabet.Length;
                    }
                    EncryptedText += alphabet[shiftedIndex];
                }
                else
                    EncryptedText += c; // Placeholder: just appending the original character
            }
            return EncryptedText;
        }
        /// <summary>
        /// Decrypts the specified text using a Caesar cipher with the given shift and alphabet type.
        /// </summary>
        /// <param name="Text"> Encrypted text to decript. Cannot be <see langword="null"/></param>
        /// <param name="shift"></param>
        /// <param name="alphabetType"></param>
        /// <returns></returns>
        public static string Decrypt(string Text, int shift, AlphabetType alphabetType, bool caseInsensitve = true)
        {
            if (Text == null)
            {
                throw new ArgumentNullException("Text may not be null");
            }
            if (!caseInsensitve)
            {
                throw new NotImplementedException("Case sensitive decryption is not implemented yet");
            }
            char[] alphabet = Alphabets.GetAlphabet(alphabetType);
            string decryptedText = string.Empty;
            for (int i = 0; i < Text.Length; i++)
            {
                char c = Text[i];
                if (alphabet.Contains(c))
                {
                    int index = Array.IndexOf(alphabet, c);
                    int shiftedIndex = (index + (shift * -1)) % alphabet.Length;
                    if (shiftedIndex < 0)
                    {
                        shiftedIndex += alphabet.Length;
                    }
                    decryptedText += alphabet[shiftedIndex];
                }
                else
                    decryptedText += c; // Placeholder: just appending the original character


            }
            return decryptedText;
        }
    }
}