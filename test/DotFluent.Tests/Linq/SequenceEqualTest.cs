using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class SequenceEqualTest
    {
        #region Methods

        [Test]
        public void FirstNullThrowsException()
        {
            IEnumerable<int> first = null;
            var second = new int[0];

            Assert.Throws<ArgumentNullException>(() => first.SequenceEqual(second, (x, y) => x == y));
        }

        [Test]
        public void SecondNullThrowsException()
        {
            var first = new int[0];
            IEnumerable<int> second = null;

            Assert.Throws<ArgumentNullException>(() => first.SequenceEqual(second, (x, y) => x == y));
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            var first = Enumerable.Empty<int>();
            var second = Enumerable.Empty<int>();
            EqualityComparison<int> comparison = null;

            Assert.Throws<ArgumentNullException>(() => first.SequenceEqual(second, comparison));
        }

        [Test]
        [TestCase(new int[0], new int[0], true)]
        [TestCase(new int[0], new[] { 1, 2, 3 }, false)]
        [TestCase(new[] { 1, 2, 3 }, new int[0], false)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 1 }, false)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, true)]
        public void SequenceEqual(IEnumerable<int> first, IEnumerable<int> second, bool expectedResult)
            => Assert.AreEqual(first.SequenceEqual(second, (x, y) => x == y), expectedResult);

        #endregion
    }
}
