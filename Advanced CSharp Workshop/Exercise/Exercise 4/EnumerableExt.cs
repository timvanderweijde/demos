using System;
using System.Collections.Generic;

namespace Exercise_4
{
    public static class EnumerableExt
    {
        public static IEnumerable<TSource> Reduce<TSource>(this IEnumerable<TSource> source,
                                                           Func<TSource, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TDestination> Map<TSource, TDestination>(this IEnumerable<TSource> source,
                                                                           Func<TSource, TDestination> selector)
        {
            throw new NotImplementedException();
        }
        
        public static IEnumerable<int> Range(int start, int count)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TResult> Empty<TResult>()
        {
            throw new NotImplementedException();
        }
    }
}