using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class MaxTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            source
                .Invoking(x => x.Max((l, r) => 0))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.Max(Comparer<int>.Default))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SourceEmptyThrowsException()
        {
            var source = Enumerable.Empty<int>();

            source
                .Invoking(x => x.Max((l, r) => 0))
                .ShouldThrow<InvalidOperationException>();
            source
                .Invoking(x => x.Max(Comparer<int>.Default))
                .ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            Comparison<int> comparison = null;

            source
                .Invoking(x => x.Max(comparison))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ComparerNullDoesNotThrowException()
        {
            var source = Enumerable.Empty<object>();
            var comparer = default(IComparer<object>);

            source
                .Invoking(x => x.Max(comparer))
                .ShouldNotThrow();
        }

        [Test]
        [TestCase(new string[0], null, 0)]
        [TestCase(new string[0], null, 1)]
        [TestCase(new string[] { null, null, null }, null, 0)]
        [TestCase(new string[] { null, null, null }, null, 1)]
        [TestCase(new[] { "A" }, "A", 0)]
        [TestCase(new[] { "A" }, "A", 1)]
        [TestCase(new[] { "A", "C", "B" }, "C", 0)]
        [TestCase(new[] { "A", "C", "B" }, "C", 1)]
        [TestCase(new[] { null, "B", null }, "B", 0)]
        [TestCase(new[] { null, "B", null }, "B", 1)]
        public void ReferenceTypeMax(IEnumerable<string> source, string expectedResult, int overload)
        {
            var result = overload switch
            {
                1 => source.Max(StringComparer.Ordinal),
                _ => source.Max(StringComparer.Ordinal.Compare)
            };

            result.ShouldBe(expectedResult);
        }

        [Test]
        [TestCase(new[] { 1 }, 1, 0)]
        [TestCase(new[] { 1 }, 1, 1)]
        [TestCase(new[] { 1, 3, 2 }, 3, 0)]
        [TestCase(new[] { 1, 3, 2 }, 3, 1)]
        public void ValueTypeMax(IEnumerable<int> source, int expectedResult, int overload)
        {
            var result = overload switch
            {
                1 => source.Max(Comparer<int>.Default),
                _ => source.Max(Comparer<int>.Default.Compare)
            };

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
