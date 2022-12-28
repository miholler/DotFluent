using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class DistinctTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Distinct((y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Distinct((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.Distinct(comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Distinct(comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> hashCodeSelector = null;

        source
            .Invoking(x => x.Distinct((y, z) => y == z, hashCodeSelector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 })]
    public void Distinct(IEnumerable<int> source, IEnumerable<int> expectedResult)
        => source
            .Distinct((x, y) => x == y)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 })]
    public void DistinctWithHashCode(IEnumerable<int> source, IEnumerable<int> expectedResult)
    {
        var hash = GetHashCode();

        source
            .Distinct((x, y) => x == y, x => x.GetHashCode() ^ hash)
            .ShouldBe(expectedResult);
    }

    #endregion
}
