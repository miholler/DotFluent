using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableDistinctByTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.DistinctBy(y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.DistinctBy(y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.DistinctBy(keySelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.DistinctBy(keySelector, (y, z) => y == z, y => y.GetHashCode()))
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
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        source
            .Invoking(x => x.DistinctBy(y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new int[0], new int[0], 0)]
    [TestCase(new int[0], new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 1)]
    [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 }, 1)]
    public void DistinctBy(IEnumerable<int> source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.DistinctBy(x => x, (x, y) => x == y, x => x.GetHashCode()),
            _ => source.DistinctBy(x => x, (x, y) => x == y)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
