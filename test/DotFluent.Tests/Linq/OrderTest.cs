using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class OrderTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Order());
            Assert.ThrowsException<ArgumentNullException>(() => source.Order((x, y) => 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.Order(Comparer<int>.Default));
        }

        [TestMethod]
        public void ComparisonNullThrowsException()
        {
            Comparison<int> comparison = null;

            Assert.ThrowsException<ArgumentNullException>(() => new int[0].Order(comparison));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
        public void Order(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.Order().SequenceEqual(expectedResult));

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
        public void OrderWithComparison(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.Order((x, y) => x > y ? 1 : x == y ? 0 : -1).SequenceEqual(expectedResult));

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
        public void OrderWithComparer(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.Order(Comparer<int>.Default).SequenceEqual(expectedResult));

        #endregion
    }
}
