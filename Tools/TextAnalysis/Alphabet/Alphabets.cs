using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tools.TextAnalysis.Language
{
    internal static class Alphabets
    {
        static readonly char[] IcelandicAlphabetPre1974 = new char[]
{
            'a','á','b','d','ð','e','é','f','g','h','i','í','j','k','l','m',
            'n','o','ó','p','r','s','t','u','ú','v','x','y','ý','z','þ','æ','ö'
};
        static readonly char[] IcelandicAlphabet = new char[]
        {
            'a','á','b','d','ð','e','é','f','g','h','i','í','j','k','l','m',
            'n','o','ó','p','r','s','t','u','ú','v','x','y','ý','þ','æ','ö'
        };
        static readonly char[] IcelandicAlphabetWithEnglishLetters = new char[]
        {
            'a','á','b','c','d','ð','e','é','f','g','h','i','í','j','k','l','m',
            'n','o','ó','p','q','r','s','t','u','ú','v','w','x','y','ý','z','þ','æ','ö'
        };

        internal static char[] GetAlphabet(AlphabetType alphabetType)
        {
            return alphabetType switch
            {
                AlphabetType.IcelandicPre1974 => IcelandicAlphabetPre1974,
                AlphabetType.Icelandic => IcelandicAlphabet,
                AlphabetType.IcelandicExtended => IcelandicAlphabetWithEnglishLetters,
                _ => throw new NotSupportedException($"The language type {alphabetType} is not supported."),
            };
        }
    }
}
