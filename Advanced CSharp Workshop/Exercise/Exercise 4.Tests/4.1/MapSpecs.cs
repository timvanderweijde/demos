using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4.Tests
{
    [TestClass]
    public class MapSpecs
    {
        [TestMethod]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Action action = () => source.Map(x => x + 1);
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void NullProjectionThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, int> projection = null;
            Action action = () => source.Map(projection);
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void EmptySource()
        {
            var source = new int[0];
            IEnumerable<int> result = source.Map(x => x);
            result.Should().BeEmpty();
        }
        
        [TestMethod]
        public void SimpleProjectionToDifferentType()
        {
            int[] source = {1, 5, 2};
            IEnumerable<string> result = source.Map(x => x.ToString());
            result.Should().Equal(new[] {"1", "5", "2"});
        }

        [TestMethod]
        public void ExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Map(x => x > 0));
        }
    }
}