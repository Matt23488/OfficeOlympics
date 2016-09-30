using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.Extensions
{
    public static class StringExtensions
    {
        public static string AsProperNoun(this string s)
        {
            return new string(s.Trim().Select((c, i) => i == 0 ? c.ToUpper() : c.ToLower()).ToArray());
        }

        public static string AsFullName(this string s)
        {
            var names = s.Trim().Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].AsProperNoun();
            }

            return names.Join(" ");
        }

        public static string Join(this string[] s, string separator)
        {
            return string.Join(separator, s);
        }
    }
}