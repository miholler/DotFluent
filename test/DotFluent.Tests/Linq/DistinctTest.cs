using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class DistinctTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.Distinct((x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.Distinct((x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            EqualityComparison<int> comparison = null;

            Assert.Throws<ArgumentNullException>(() => source.Distinct(comparison));
            Assert.Throws<ArgumentNullException>(() => source.Distinct(comparison, x => x.GetHashCode()));
        }

        [Test]
        public void HashCodeSelectorNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int> hashCodeSelector = null;

            Assert.Throws<ArgumentNullException>(() => source.Distinct((x, y) => x == y, hashCodeSelector));
        }

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 })]
        public void Distinct(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.Distinct((x, y) => x == y).SequenceEqual(expectedResult));

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 })]
        public void DistinctWithHashCode(IEnumerable<int> source, IEnumerable<int> expectedResult)
        {
            var hash = GetHashCode();
            Assert.IsTrue(source.Distinct((x, y) => x == y, x => x.GetHashCode() ^ hash).SequenceEqual(expectedResult));
        }

        #endregion
    }
}
