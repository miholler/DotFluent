using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestClass]
    public sealed class OrderByTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.OrderBy(x => x, (x, y) => 0));
        }

        [TestMethod]
        public void ComparisonNullThrowsException()
        {
            Comparison<int> comparison = null;

            Assert.ThrowsException<ArgumentNullException>(() => new int[0].OrderBy(x => x, comparison));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
        public void OrderBy(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderBy(x => x, (x, y) => x > y ? 1 : x == y ? 0 : -1).SequenceEqual(expectedResult));

        #endregion
    }
}
