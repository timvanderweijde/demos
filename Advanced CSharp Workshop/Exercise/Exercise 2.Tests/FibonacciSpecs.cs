using System.Collections.Generic;
using System.Linq;
using Exercise2;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_2.Tests
{
    [TestClass]
    public class FibonacciSpecs
    {
        [TestMethod]
        public void Range()
        {
            IEnumerable<int> result = FibonacciGenerator.Generate().Take(10).ToArray();
            result.Should().Equal(new[] {0, 1, 1, 2, 3, 5, 8, 13, 21, 34});
        }
    }
}