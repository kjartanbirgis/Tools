using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.TextAnalysis.Language
{
    internal static class Alphabets
    {
        static readonly string[] IcelandicAlphabetUpperCases = new string[]
        {
            "A","Á","B","D","Ð","E","É","F","G","H","I","Í","J","K","L","M",
            "N","O","Ó","P","R","S","T","U","Ú","V","X","Y","Ý","Z","Þ","Æ","Ö"
        };
        static readonly string[] IcelandicAlphabetBothCases = new string[]
        {
            "A","Á","B","D","Ð","E","É","F","G","H","I","Í","J","K","L","M",
            "N","O","Ó","P","R","S","T","U","Ú","V","X","Y","Ý","Z","Þ","Æ","Ö",
            "a","á","b","d","ð","e","é","f","g","h","i","í","j","k","l","m",
            "n","o","ó","p","r","s","t","u","ú","v","x","y","ý","z","þ","æ","ö"
        };
        static readonly string[] IcelandicAlphabetLowerCases = new string[]
        {
            "a","á","b","d","ð","e","é","f","g","h","i","í","j","k","l","m",
            "n","o","ó","p","r","s","t","u","ú","v","x","y","ý","z","þ","æ","ö"
        };
        static readonly string[] IcelandicAlphabetLowerCasesWithEnglishLetters = new string[]
        {
            "a","á","b","c","d","ð","e","é","f","g","h","i","í","j","k","l","m",
            "n","o","ó","p","q","r","s","t","u","ú","v","w","x","y","ý","z","þ","æ","ö"
        };
    }
}
