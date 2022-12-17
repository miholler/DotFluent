using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class MaxByTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            source
                .Invoking(x => x.MaxBy(y => y))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.MaxBy(y => y, (l, r) => 0))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.MaxBy(y => y, Comparer<int>.Default))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SourceEmptyThrowsException()
        {
            var source = Enumerable.Empty<int>();

            source
                .Invoking(x => x.MaxBy(y => y))
                .ShouldThrow<InvalidOperationException>();
            source
                .Invoking(x => x.MaxBy(y => y, (l, r) => 0))
                .ShouldThrow<InvalidOperationException>();
            source
                .Invoking(x => x.MaxBy(y => y, Comparer<int>.Default))
                .ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            source
                .Invoking(x => x.MaxBy(keySelector))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.MaxBy(keySelector, (l, r) => 0))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.MaxBy(keySelector, Comparer<int>.Default))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            Comparison<int> comparison = null;

            source
                .Invoking(x => x.MaxBy(y => y, comparison))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(new string[0], null, 0)]
        [TestCase(new string[0], null, 1)]
        [TestCase(new string[0], null, 2)]
        [TestCase(new string[] { null, null, null }, null, 0)]
        [TestCase(new string[] { null, null, null }, null, 1)]
        [TestCase(new string[] { null, null, null }, null, 2)]
        [TestCase(new[] { "A" }, "A", 0)]
        [TestCase(new[] { "A" }, "A", 1)]
        [TestCase(new[] { "A" }, "A", 2)]
        [TestCase(new[] { "A", "B", "C" }, "C", 0)]
        [TestCase(new[] { "A", "B", "C" }, "C", 1)]
        [TestCase(new[] { "A", "B", "C" }, "C", 2)]
        [TestCase(new[] { "A", "C", "B" }, "C", 0)]
        [TestCase(new[] { "A", "C", "B" }, "C", 1)]
        [TestCase(new[] { "A", "C", "B" }, "C", 2)]
        [TestCase(new[] { null, "B", null }, "B", 0)]
        [TestCase(new[] { null, "B", null }, "B", 1)]
        [TestCase(new[] { null, "B", null }, "B", 2)]
        public void ReferenceTypeMaxBy(IEnumerable<string> source, string expectedResult, int overload)
        {
            var result = overload switch
            {
                1 => source.MaxBy(x => x, StringComparer.Ordinal.Compare),
                2 => source.MaxBy(x => x, StringComparer.Ordinal),
                _ => source.MaxBy(x => x)
            };

            result.ShouldBe(expectedResult);
        }

        [Test]
        [TestCase(new[] { 1 }, 1, 0)]
        [TestCase(new[] { 1 }, 1, 1)]
        [TestCase(new[] { 1 }, 1, 2)]
        [TestCase(new[] { 1, 2, 3 }, 3, 0)]
        [TestCase(new[] { 1, 2, 3 }, 3, 1)]
        [TestCase(new[] { 1, 2, 3 }, 3, 2)]
        [TestCase(new[] { 1, 3, 2 }, 3, 0)]
        [TestCase(new[] { 1, 3, 2 }, 3, 1)]
        [TestCase(new[] { 1, 3, 2 }, 3, 2)]
        public void ValueTypeMax(IEnumerable<int> source, int expectedResult, int overload)
        {
            var result = overload switch
            {
                1 => source.MaxBy(x => x, Comparer<int>.Default.Compare),
                2 => source.MaxBy(x => x, Comparer<int>.Default),
                _ => source.MaxBy(x => x)
            };

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
