using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestClass]
    public sealed class IntersectTest
    {
        #region Methods

        [TestMethod]
        public void FirstNullThrowsException()
        {
            IEnumerable<int> first = null;
            var second = new int[0];

            Assert.ThrowsException<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void SecondNullThrowsException()
        {
            var first = new int[0];
            IEnumerable<int> second = null;

            Assert.ThrowsException<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            var first = new int[0];
            var second = new int[0];
            Func<int, int, bool> comparer = null;

            Assert.ThrowsException<ArgumentNullException>(() => first.Intersect(second, comparer));
            Assert.ThrowsException<ArgumentNullException>(() => first.Intersect(second, comparer, x => x.GetHashCode()));
        }

        [TestMethod]
        public void HashCodeProviderNullThrowsException()
        {
            var first = new int[0];
            var second = new int[0];
            Func<int, int> hashCodeProvider = null;

            Assert.ThrowsException<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y, hashCodeProvider));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0], new int[0])]
        [DataRow(new int[0], new[] { 1, 2, 3 }, new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new int[0], new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 })]
        public void Intersect(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
            => Assert.IsTrue(first.Intersect(second, (x, y) => x == y).SequenceEqual(expectedResult));

        [TestMethod]
        [DataRow(new int[0], new int[0], new int[0])]
        [DataRow(new int[0], new[] { 1, 2, 3 }, new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new int[0], new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 })]
        public void IntersectWithHashCode(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
        {
            var hash = GetHashCode();
            Assert.IsTrue(first.Intersect(second, (x, y) => x == y, x => x.GetHashCode() ^ hash).SequenceEqual(expectedResult));
        }

        #endregion
    }
}
