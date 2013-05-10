using System;
using System.Collections.Generic;

namespace Exercise_4
{
    public static class EnumerableExt
    {
        public static IEnumerable<TSource> Reduce<TSource>(this IEnumerable<TSource> source,
                                                           Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (predicate == null)
            {
                throw new ArgumentNullException();
            }
            
            return ReduceImpl(source, predicate);
        }

        public static IEnumerable<TSource> ReduceImpl<TSource>(this IEnumerable<TSource> source,
                                                           Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TDestination> Map<TSource, TDestination>(this IEnumerable<TSource> source,
                                                                           Func<TSource, TDestination> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            return MapImpl(source, selector);
        }

        public static IEnumerable<TDestination> MapImpl<TSource, TDestination>(this IEnumerable<TSource> source,
                                                                               Func<TSource, TDestination> selector)
        {
            foreach (TSource element in source)
            {
                yield return selector(element);
            }
        }

        private static IEnumerable<TResult> Generate<TResult>(TResult start, Func<TResult, TResult> accumelator)
        {
            TResult previous = start;

            yield return start;

            while (true)
            {
                previous = accumelator(previous);
                
                yield return previous;
            }
        }

        private static IEnumerable<TResult> Take<TResult>(this IEnumerable<TResult> source, int count)
        {
            int counter = 0;
            foreach (TResult item in source)
            {
                if (counter == count)
                {
                    yield break;
                }

                counter++;
                yield return item;
            }
        }

        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if ((long)(start + count) > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Generate(start, prev => prev + 1).Take(count);
        }

        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Generate(element, x => element).Take(count);
        }

        public static IEnumerable<TResult> Empty<TResult>()
        {
            throw new NotImplementedException();
        }
    }
}