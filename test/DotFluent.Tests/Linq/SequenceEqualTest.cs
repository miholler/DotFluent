using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class SequenceEqualTest
    {
        #region Methods

        [TestMethod]
        public void FirstNullThrowsException()
        {
            IEnumerable<int> first = null;
            var second = new int[0];

            Assert.ThrowsException<ArgumentNullException>(() => first.SequenceEqual(second, (x, y) => x == y));
        }

        [TestMethod]
        public void SecondNullThrowsException()
        {
            var first = new int[0];
            IEnumerable<int> second = null;

            Assert.ThrowsException<ArgumentNullException>(() => first.SequenceEqual(second, (x, y) => x == y));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            var first = new int[0];
            var second = new int[0];
            Func<int, int, bool> comparer = null;

            Assert.ThrowsException<ArgumentNullException>(() => first.SequenceEqual(second, comparer));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0], true)]
        [DataRow(new int[0], new[] { 1, 2, 3 }, false)]
        [DataRow(new[] { 1, 2, 3 }, new int[0], false)]
        [DataRow(new[] { 1, 2, 3 }, new[] { 3, 2, 1 }, false)]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, true)]
        public void SequenceEqual(IEnumerable<int> first, IEnumerable<int> second, bool expectedResult)
            => Assert.AreEqual(first.SequenceEqual(second, (x, y) => x == y), expectedResult);

        #endregion
    }
}
