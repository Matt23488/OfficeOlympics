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
    }
}