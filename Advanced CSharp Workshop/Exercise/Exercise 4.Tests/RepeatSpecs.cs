using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4.Tests
{
    [TestClass]
    public class RepeatSpecs
    {
        [TestMethod]
        public void SimpleRepeat()
        {
            EnumerableExt.Repeat("foo", 3).Should().Equal(new[] {"foo", "foo", "foo"});
        }

        [TestMethod]
        public void EmptyRepeat()
        {
            EnumerableExt.Repeat("foo", 0).Should().BeEmpty();
        }

        [TestMethod]
        public void NullElement()
        {
            EnumerableExt.Repeat<string>(null, 2).Should().Equal(new string[] {null, null});
        }

        [TestMethod]
        public void NegativeCount()
        {
            Action action = () => EnumerableExt.Repeat("foo", -1);
            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void RepeatIsDeferred()
        {
            EnumerableExt.Repeat(0, int.MaxValue);

            // Assume it's alright if it doesn't throw an OutOfMemoryException
        }
    }
}