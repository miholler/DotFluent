using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class IntersectTest
    {
        #region Methods

        [Test]
        public void FirstNullThrowsException()
        {
            IEnumerable<int> first = null;
            var second = new int[0];

            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void SecondNullThrowsException()
        {
            var first = new int[0];
            IEnumerable<int> second = null;

            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ComparerNullThrowsException()
        {
            var first = new int[0];
            var second = new int[0];
            Func<int, int, bool> comparer = null;

            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, comparer));
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, comparer, x => x.GetHashCode()));
        }

        [Test]
        public void HashCodeProviderNullThrowsException()
        {
            var first = new int[0];
            var second = new int[0];
            Func<int, int> hashCodeProvider = null;

            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, (x, y) => x == y, hashCodeProvider));
        }

        [Test]
        [TestCase(new int[0], new int[0], new int[0])]
        [TestCase(new int[0], new[] { 1, 2, 3 }, new int[0])]
        [TestCase(new[] { 1, 2, 3 }, new int[0], new int[0])]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 })]
        public void Intersect(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
            => Assert.IsTrue(first.Intersect(second, (x, y) => x == y).SequenceEqual(expectedResult));

        [Test]
        [TestCase(new int[0], new int[0], new int[0])]
        [TestCase(new int[0], new[] { 1, 2, 3 }, new int[0])]
        [TestCase(new[] { 1, 2, 3 }, new int[0], new int[0])]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 })]
        public void IntersectWithHashCode(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
        {
            var hash = GetHashCode();
            Assert.IsTrue(first.Intersect(second, (x, y) => x == y, x => x.GetHashCode() ^ hash).SequenceEqual(expectedResult));
        }

        #endregion
    }
}
