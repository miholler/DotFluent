using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class MinTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Min((y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Min(Comparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SourceEmptyThrowsException()
    {
        var source = Enumerable.Empty<int>();

        source
            .Invoking(x => x.Min((y, z) => 0))
            .ShouldThrow<InvalidOperationException>();
        source
            .Invoking(x => x.Min(Comparer<int>.Default))
            .ShouldThrow<InvalidOperationException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x.Min(comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparerNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<object>();
        var comparer = default(IComparer<object>);

        source
            .Invoking(x => x.Min(comparer))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new string[0], null, 0)]
    [TestCase(new string[0], null, 1)]
    [TestCase(new string[] { null, null, null }, null, 0)]
    [TestCase(new string[] { null, null, null }, null, 1)]
    [TestCase(new[] { "A" }, "A", 0)]
    [TestCase(new[] { "A" }, "A", 1)]
    [TestCase(new[] { "C", "A", "B" }, "A", 0)]
    [TestCase(new[] { "C", "A", "B" }, "A", 1)]
    [TestCase(new[] { null, "B", null }, "B", 0)]
    [TestCase(new[] { null, "B", null }, "B", 1)]
    public void ReferenceTypeMin(IEnumerable<string> source, string expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.Min(StringComparer.Ordinal),
            _ => source.Min(StringComparer.Ordinal.Compare)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(new[] { 1 }, 1, 0)]
    [TestCase(new[] { 1 }, 1, 1)]
    [TestCase(new[] { 3, 1, 2 }, 1, 0)]
    [TestCase(new[] { 3, 1, 2 }, 1, 1)]
    public void ValueTypeMin(IEnumerable<int> source, int expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.Min(Comparer<int>.Default),
            _ => source.Min(Comparer<int>.Default.Compare)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
