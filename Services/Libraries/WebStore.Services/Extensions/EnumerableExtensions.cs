using System;
using System.Collections.Generic;

namespace WebStore.Services.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> ext, Action<T> action)
        {
            foreach (var item in ext)
                action?.Invoke(item);
            return ext;
        }
    }
}
