using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Tools.TextAnalysis.Language;

namespace Tools.TextAnalysis
{
    public class FrequencyCounter
    {
        public Dictionary<string,int> CountFrequencies(string text)
        {
            var frequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var words = text.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;
                }
                else
                {
                    frequencies[word] = 1;
                }
            }
            return frequencies;
        }
        static public Dictionary<char,int> CountCharacterFrequencies(string text, AlphabetType alphabetType)
        {
            string textLower = text.ToLowerInvariant();
            char[] alphabet = Language.Alphabets.GetAlphabet(alphabetType);
            var filteredText = new string(textLower.Where(c => alphabet.Contains(c)).ToArray());
            var frequencies = new Dictionary<char, int>();
            foreach (var ch in filteredText)
            {
                //if (char.IsWhiteSpace(ch)) continue;
                if (frequencies.ContainsKey(ch))
                {
                    frequencies[ch]++;
                }
                else
                {
                    frequencies[ch] = 1;
                }
            }
            return frequencies;
        }
    }
}
