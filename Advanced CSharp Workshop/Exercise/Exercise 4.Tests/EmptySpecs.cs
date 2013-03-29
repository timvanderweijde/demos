using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4.Tests
{
    [TestClass]
    public class EmptySpecs
    {
        [TestMethod]
        public void EmptyContainsNoElements()
        {
            using (IEnumerator<int> empty = EnumerableExt.Empty<int>().GetEnumerator())
            {
                Assert.IsFalse(empty.MoveNext());
            }
        }

        [TestMethod]
        public void EmptyIsASingletonPerElementType()
        {
            Assert.AreSame(EnumerableExt.Empty<int>(), EnumerableExt.Empty<int>());
            Assert.AreSame(EnumerableExt.Empty<long>(), EnumerableExt.Empty<long>());
            Assert.AreSame(EnumerableExt.Empty<string>(), EnumerableExt.Empty<string>());
            Assert.AreSame(EnumerableExt.Empty<object>(), EnumerableExt.Empty<object>());

            Assert.AreNotSame(EnumerableExt.Empty<long>(), EnumerableExt.Empty<int>());
            Assert.AreNotSame(EnumerableExt.Empty<string>(), EnumerableExt.Empty<object>());
        }

        [TestMethod]
        public void EmptyIsImmutable()
        {
            IEnumerable<int> empty = EnumerableExt.Empty<int>();

            var collection = empty as ICollection<int>;
            if (collection == null)
                return; // If it's not a collection, it's not a problem.

            // Adding elements to our empty enumerable would be... strange.
            Action action = () => collection.Add(3);
            action.ShouldThrow<NotSupportedException>();
        }
    }
}