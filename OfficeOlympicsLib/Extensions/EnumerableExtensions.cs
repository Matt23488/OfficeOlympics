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

        public static IEnumerable<T> UniqueConstraint<T, TProp>(this IEnumerable<T> source, Func<T, TProp> selector)
        {
            var cache = new List<TProp>();

            foreach (var item in source)
            {
                var uniqueValue = selector(item);
                if (cache.Contains(uniqueValue)) continue;

                cache.Add(uniqueValue);
                yield return item;
            }
        }

        public static int? FirstIndexWhere<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (condition(item)) return index;
                index++;
            }

            return null;
        }
    }
}
