using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;

namespace Exercise_4.Tests
{
    /// <summary>
    ///     Class to help for deferred execution tests: it throw an exception
    ///     if GetEnumerator is called.
    /// </summary>
    internal sealed class ThrowingEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Check that the given function uses deferred execution.
        ///     A "spiked" source is given to the function: the function
        ///     call itself shouldn't throw an exception. However, using
        ///     the result (by calling GetEnumerator() then MoveNext() on it) *should*
        ///     throw InvalidOperationException.
        /// </summary>
        internal static void AssertDeferred<T>(
            Func<IEnumerable<int>, IEnumerable<T>> deferredFunction)
        {
            var source = new ThrowingEnumerable();
            IEnumerable<T> result = deferredFunction(source);
            using (IEnumerator<T> iterator = result.GetEnumerator())
            {
                Action action = () => iterator.MoveNext();
                action.ShouldThrow<InvalidOperationException>();
            }
        }
    }
}