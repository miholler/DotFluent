using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class DistinctByTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            source
                .Invoking(x => x.DistinctBy(y => y))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.DistinctBy(y => y, (l, r) => l == r))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.DistinctBy(y => y, (l, r) => l == r, y => y.GetHashCode()))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.DistinctBy(y => y, EqualityComparer<int>.Default))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            source
                .Invoking(x => x.DistinctBy(keySelector))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.DistinctBy(keySelector, (l, r) => l == r))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.DistinctBy(keySelector, (l, r) => l == r, y => y.GetHashCode()))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.DistinctBy(keySelector, EqualityComparer<int>.Default))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            EqualityComparison<int> comparison = null;

            source
                .Invoking(x => x.DistinctBy(y => y, comparison))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.DistinctBy(y => y, comparison, y => y.GetHashCode()))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void HashCodeSelectorNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int> hashCodeSelector = null;

            source
                .Invoking(x => x.DistinctBy(y => y, (l, r) => l == r, hashCodeSelector))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(new int[0], new int[0], 0)]
        [TestCase(new int[0], new int[0], 1)]
        [TestCase(new int[0], new int[0], 2)]
        [TestCase(new int[0], new int[0], 3)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 0)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 1)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 2)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 3)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 }, 0)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 }, 1)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 }, 2)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 }, 3)]
        public void DistinctBy(IEnumerable<int> source, IEnumerable<int> expectedResult, int overload)
        {
            var result = overload switch
            {
                1 => source.DistinctBy(y => y, (l, r) => l == r),
                2 => source.DistinctBy(y => y, (l, r) => l == r, y => y.GetHashCode()),
                3 => source.DistinctBy(y => y, EqualityComparer<int>.Default),
                _ => source.DistinctBy(y => y)
            };

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
