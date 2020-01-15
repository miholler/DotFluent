using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class OrderByDescendingTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.OrderByDescending(x => x, (x, y) => 0));
        }

        [TestMethod]
        public void ComparisonNullThrowsException()
        {
            Comparison<int> comparison = null;

            Assert.ThrowsException<ArgumentNullException>(() => new int[0].OrderByDescending(x => x, comparison));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
        public void OrderByDescending(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderByDescending(x => x, (x, y) => x > y ? 1 : x == y ? 0 : -1).SequenceEqual(expectedResult));

        #endregion
    }
}
