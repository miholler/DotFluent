using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableIntersectTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void FirstOrSecondNullThrowsException(IEnumerable<int> first, IEnumerable<int> second)
    {
        first
            .Invoking(x => x.Intersect(second, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.Intersect(second, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        first
            .Invoking(x => x.Intersect(second, comparison))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.Intersect(second, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        first
            .Invoking(x => x.Intersect(second, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new int[0], new int[0], new int[0], 0)]
    [TestCase(new int[0], new int[0], new int[0], 1)]
    [TestCase(new int[0], new[] { 1, 2, 3 }, new int[0], 0)]
    [TestCase(new int[0], new[] { 1, 2, 3 }, new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, new int[0], new int[0], 0)]
    [TestCase(new[] { 1, 2, 3 }, new int[0], new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 0 }, new[] { 2, 3 }, 1)]
    public void Intersect(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => first.Intersect(second, (x, y) => x == y, x => x.GetHashCode()),
            _ => first.Intersect(second, (x, y) => x == y)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
