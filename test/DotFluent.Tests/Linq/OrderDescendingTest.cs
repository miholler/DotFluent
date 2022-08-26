using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class OrderDescendingTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.OrderDescending());
            Assert.Throws<ArgumentNullException>(() => source.OrderDescending((x, y) => 0));
            Assert.Throws<ArgumentNullException>(() => source.OrderDescending(Comparer<int>.Default));
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            Comparison<int> comparison = null;

            Assert.Throws<ArgumentNullException>(() => Array.Empty<int>().OrderDescending(comparison));
        }

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
        public void OrderDescending(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderDescending().SequenceEqual(expectedResult));

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
        public void OrderDescendingWithComparison(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderDescending((x, y) => x > y ? 1 : x == y ? 0 : -1).SequenceEqual(expectedResult));

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
        public void OrderDescendingWithComparer(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderDescending(Comparer<int>.Default).SequenceEqual(expectedResult));

        #endregion
    }
}
