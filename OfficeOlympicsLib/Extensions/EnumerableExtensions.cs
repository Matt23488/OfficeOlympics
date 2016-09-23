using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Extensions
{
    internal static class EnumerableExtensions
    {
        public static T ItemWithMaxOrDefault<T, TProp>(this IEnumerable<T> source, Func<T, TProp> selector)
        {
            return source.OrderByDescending(selector).FirstOrDefault();
        }
    }
}
