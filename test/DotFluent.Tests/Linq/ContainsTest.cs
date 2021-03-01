using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestClass]
    public sealed class ContainsTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Contains(0, (x, y) => x == y));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            var source = new int[0];
            Func<int, int, bool> comparer = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Contains(1, comparer));
        }

        [TestMethod]
        [DataRow(new int[0], 0, false)]
        [DataRow(new int[] { 1, 2, 3 }, 4, false)]
        [DataRow(new int[] { 1, 2, 3 }, 2, true)]
        public void Contains(IEnumerable<int> source, int value, bool expectedResult)
            => Assert.AreEqual(source.Contains(value, (x, y) => x == y), expectedResult);

        #endregion
    }
}
