using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Extensions
{
    public static class EnumerableExtension
    {
        public static string Join<T, T2>(this IEnumerable<T> list, Func<T, T2> exp)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in list)
            {
                builder.AppendFormat("{0},", exp(item).ToString());
            }

            if (builder.Length > 0)
                builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }
    }
}
