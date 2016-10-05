using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.Extensions
{
    public static class CharExtensions
    {
        private const string _lowerCaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string _upperCaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static char ToUpper(this char c)
        {
            int alphabetIndex = _lowerCaseAlphabet.IndexOf(c);

            if (alphabetIndex == -1) return c;
            else return _upperCaseAlphabet[alphabetIndex];
        }

        public static char ToLower(this char c)
        {
            int alphabetIndex = _upperCaseAlphabet.IndexOf(c);

            if (alphabetIndex == -1) return c;
            else return _lowerCaseAlphabet[alphabetIndex];
        }

        public static bool IsLetter(this char c)
        {
            return char.IsLetter(c);
        }
    }
}