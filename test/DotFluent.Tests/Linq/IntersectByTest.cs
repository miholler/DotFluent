using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class IntersectByTest
    {
        #region Methods

        [Test]
        public void FirstNullThrowsException()
        {
            IEnumerable<int> first = null;
            var second = Enumerable.Empty<int>();

            first
                .Invoking(x => x.IntersectBy(second, y => y))
                .ShouldThrow<ArgumentNullException>();
            first
                .Invoking(x => x.IntersectBy(second, y => y, (l, r) => l == r))
                .ShouldThrow<ArgumentNullException>();
            first
                .Invoking(x => x.IntersectBy(second, y => y, (l, r) => l == r, y => y.GetHashCode()))
                .ShouldThrow<ArgumentNullException>();
            first
                .Invoking(x => x.IntersectBy(second, y => y, EqualityComparer<int>.Default))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SecondNullThrowsException()
        {
            var first = Enumerable.Empty<int>();
            IEnumerable<int> second = null;

            first
                .Invoking(x => x.IntersectBy(second, y => y))
                .ShouldThrow<ArgumentNullException>();
            first
                .Invoking(x => x.IntersectBy(second, y => y, (l, r) => l == r))
                .ShouldThrow<ArgumentNullException>();
            first
                .Invoking(x => x.IntersectBy(second, y => y, (l, r) => l == r, y => y.GetHashCode()))
                .ShouldThrow<ArgumentNullException>();
            first
                .Invoking(x => x.IntersectBy(second, y => y, EqualityComparer<int>.Default))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ComparerNullThrowsException()
        {
            var first = Enumerable.Empty<int>();
            var second = Enumerable.Empty<int>();
            Func<int, int, bool> comparer = null;

            first
                .Invoking(x => x.IntersectBy(second, y => y, comparer))
                .ShouldThrow<ArgumentNullException>();
            first
                .Invoking(x => x.IntersectBy(second, y => y, comparer, y => y.GetHashCode()))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void HashCodeProviderNullThrowsException()
        {
            var first = Enumerable.Empty<int>();
            var second = Enumerable.Empty<int>();
            Func<int, int> hashCodeProvider = null;

            first
                .Invoking(x => x.IntersectBy(second, y => y, (l, r) => l == r, hashCodeProvider))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(new int[0], new int[0], new int[0], 0)]
        [TestCase(new int[0], new int[0], new int[0], 1)]
        [TestCase(new int[0], new int[0], new int[0], 2)]
        [TestCase(new int[0], new int[0], new int[0], 3)]
        [TestCase(new int[0], new[] { 1, 2, 3 }, new int[0], 0)]
        [TestCase(new int[0], new[] { 1, 2, 3 }, new int[0], 1)]
        [TestCase(new int[0], new[] { 1, 2, 3 }, new int[0], 2)]
        [TestCase(new int[0], new[] { 1, 2, 3 }, new int[0], 3)]
        [TestCase(new[] { 1, 2, 3 }, new int[0], new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, new int[0], new int[0], 1)]
        [TestCase(new[] { 1, 2, 3 }, new int[0], new int[0], 2)]
        [TestCase(new[] { 1, 2, 3 }, new int[0], new int[0], 3)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 }, 0)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 }, 1)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 }, 2)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 }, 3)]
        public void IntersectBy(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult, int overload)
        {
            var result = overload switch
            {
                1 => first.IntersectBy(second, y => y, (l, r) => l == r),
                2 => first.IntersectBy(second, y => y, (l, r) => l == r, y => y.GetHashCode()),
                3 => first.IntersectBy(second, y => y, EqualityComparer<int>.Default),
                _ => first.IntersectBy(second, y => y)
            };

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
