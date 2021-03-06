﻿
using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4.Tests
{
    [TestClass]
    public class ReduceSpecs
    {
        [TestMethod]
        public void SimpleFiltering()
        {
            int[] source = {1, 3, 4, 2, 8, 1};
            IEnumerable<int> result = source.Reduce(x => x < 4);
            result.Should().Equal(new[] {1, 3, 2, 1});
        }

        [TestMethod]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Action action = () => source.Reduce(x => x > 5);
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] source = {1, 3, 7, 9, 10};
            Func<int, bool> predicate = null;
            Action action = () => source.Reduce(predicate);
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Reduce(x => x > 0));
        }
    }
}