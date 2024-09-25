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
    }

    [Test]
    public void SourceEmptyThrowsException()
    {
        var source = Enumerable.Empty<int>();

        source
            .Invoking(x => x.Min((y, z) => 0))
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
    [TestCase(new string[0], null)]
    [TestCase(new string[] { null, null, null }, null)]
    [TestCase(new[] { "A" }, "A")]
    [TestCase(new[] { "C", "A", "B" }, "A")]
    [TestCase(new[] { null, "B", null }, "B")]
    public void ReferenceTypeMin(IEnumerable<string> source, string expectedResult)
        => source
            .Min(StringComparer.Ordinal.Compare)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { 3, 1, 2 }, 1)]
    public void ValueTypeMin(IEnumerable<int> source, int expectedResult)
        => source
            .Min(Comparer<int>.Default.Compare)
            .ShouldBe(expectedResult);

    #endregion
}
