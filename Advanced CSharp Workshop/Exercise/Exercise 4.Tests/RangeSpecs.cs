using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_4.Tests
{
    [TestClass]
    public class RangeSpecs
    {
        [TestMethod]
        public void NegativeCount()
        {
            Action action = () => EnumerableExt.Range(10, -1);
            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void CountTooLarge()
        {
            Action action = () => EnumerableExt.Range(int.MaxValue, 2);
            action.ShouldThrow<ArgumentOutOfRangeException>();

            action = () => EnumerableExt.Range(2, int.MaxValue);
            action.ShouldThrow<ArgumentOutOfRangeException>();

            // int.MaxValue is odd, hence the +3 instead of +2
            action = () => EnumerableExt.Range(int.MaxValue / 2, (int.MaxValue / 2) + 3);
            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void LargeButValidCount()
        {
            // Essentially the edge conditions for CountTooLarge, but just below the boundary
            EnumerableExt.Range(int.MaxValue, 1);
            EnumerableExt.Range(1, int.MaxValue);
            EnumerableExt.Range(int.MaxValue / 2, (int.MaxValue / 2) + 2);
        }

        [TestMethod]
        public void ValidRange()
        {
            EnumerableExt.Range(5, 3).Should().Equal(new[] { 5, 6, 7 });
        }

        [TestMethod]
        public void NegativeStart()
        {
            EnumerableExt.Range(-2, 5).Should().Equal(new[] { -2, -1, 0, 1, 2 });
        }

        [TestMethod]
        public void EmptyRange()
        {
            EnumerableExt.Range(100, 0).Should().BeEmpty();
        }

        [TestMethod]
        public void SingleValueOfMaxInt32()
        {
            EnumerableExt.Range(int.MaxValue, 1).Should().Equal(new[] { int.MaxValue });
        }

        [TestMethod]
        public void EmptyRangeStartingAtMinInt32()
        {
            EnumerableExt.Range(int.MinValue, 0).Should().BeEmpty();
        }

        [TestMethod]
        public void RangeIsDeferred()
        {
            EnumerableExt.Range(0, int.MaxValue);
            // Assume it's alright if it doesn't throw an OutOfMemoryException
        }
    }
}