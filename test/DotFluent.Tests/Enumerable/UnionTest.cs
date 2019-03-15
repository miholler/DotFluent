using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class UnionTest
    {
        #region Methods

        [TestMethod]
        public void FirstNullThrowsException()
        {
            IEnumerable<int> first = null;
            var second = new int[0];

            Assert.ThrowsException<ArgumentNullException>(() => first.Union(second, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => first.Union(second, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void SecondNullThrowsException()
        {
            var first = new int[0];
            IEnumerable<int> second = null;

            Assert.ThrowsException<ArgumentNullException>(() => first.Union(second, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => first.Union(second, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            var first = new int[0];
            var second = new int[0];

            Assert.ThrowsException<ArgumentNullException>(() => first.Union(second, null));
            Assert.ThrowsException<ArgumentNullException>(() => first.Union(second, null, x => x.GetHashCode()));
        }

        [TestMethod]
        public void HashCodeProviderNullThrowsException()
        {
            var first = new int[0];
            var second = new int[0];

            Assert.ThrowsException<ArgumentNullException>(() => first.Union(second, (x, y) => x == y, null));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0], new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 })]
        public void Union(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
            => Assert.IsTrue(first.Union(second, (x, y) => x == y).SequenceEqual(expectedResult));

        [TestMethod]
        [DataRow(new int[0], new int[0], new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 })]
        public void UnionWithHashCode(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
        {
            var hash = GetHashCode();
            Assert.IsTrue(first.Union(second, (x, y) => x == y, x => x.GetHashCode() ^ hash).SequenceEqual(expectedResult));
        }

        #endregion
    }
}
