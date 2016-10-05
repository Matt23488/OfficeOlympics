using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OfficeOlympicsWeb.Extensions
{
    public static class StringExtensions
    {
        public static string AsProperNoun(this string s)
        {
            var builder = new StringBuilder();
            bool newWord = true;

            foreach (char c in s)
            {
                if (newWord && c.IsLetter())
                {
                    builder.Append(c.ToUpper());
                    newWord = false;
                }
                else if (!c.IsLetter() && c != '-')
                {
                    builder.Append(c);
                    newWord = true;
                }
                else builder.Append(c.ToLower());
            }

            return builder.ToString();
        }
    }
}