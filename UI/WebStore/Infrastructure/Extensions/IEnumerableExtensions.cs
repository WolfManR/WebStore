using System;
using System.Collections.Generic;

namespace WebStore.Infrastructure.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> ext, Action<T> action)
        {
            foreach (var item in ext)
                action?.Invoke(item);
            return ext;
        }
    }
}
