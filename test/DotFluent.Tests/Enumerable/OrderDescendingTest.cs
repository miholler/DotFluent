using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class OrderDescendingTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.OrderDescending());
            Assert.ThrowsException<ArgumentNullException>(() => source.OrderDescending((x, y) => 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.OrderDescending(Comparer<int>.Default));
        }

        [TestMethod]
        public void ComparisonNullThrowsException()
        {
            Comparison<int> comparison = null;

            Assert.ThrowsException<ArgumentNullException>(() => new int[0].OrderDescending(comparison));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
        public void OrderDescending(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderDescending().SequenceEqual(expectedResult));

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
        public void OrderDescendingWithComparison(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderDescending((x, y) => x > y ? 1 : x == y ? 0 : -1).SequenceEqual(expectedResult));

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
        public void OrderDescendingWithComparer(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderDescending(Comparer<int>.Default).SequenceEqual(expectedResult));

        #endregion
    }
}
