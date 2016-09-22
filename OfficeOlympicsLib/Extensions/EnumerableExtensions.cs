using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Extensions
{
    internal static class EnumerableExtensions
    {
        public static T ItemWithMax<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            return source.OrderByDescending(selector).First();
        }
    }
}
