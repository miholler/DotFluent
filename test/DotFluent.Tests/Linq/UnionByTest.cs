using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class UnionByTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void FirstOrSecondNullThrowsException(IEnumerable<int> first, IEnumerable<int> second)
    {
        first
            .Invoking(x => x.UnionBy(second, y => y))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.UnionBy(second, y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.UnionBy(second, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.UnionBy(second, y => y, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        first
            .Invoking(x => x.UnionBy(second, keySelector))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.UnionBy(second, keySelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.UnionBy(second, keySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.UnionBy(second, keySelector, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        first
            .Invoking(x => x.UnionBy(second, y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.UnionBy(second, y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        Func<int, int> hashCodeSelector = null;

        first
            .Invoking(x => x.UnionBy(second, y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0], new int[0], 0)]
    [TestCase(new int[0], new int[0], new int[0], 1)]
    [TestCase(new int[0], new int[0], new int[0], 2)]
    [TestCase(new int[0], new int[0], new int[0], 3)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 2)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 3)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 }, 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 }, 2)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 }, 3)]
    public void UnionBy(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => first.UnionBy(second, y => y, (y, z) => y == z),
            2 => first.UnionBy(second, y => y, (y, z) => y == z, y => y.GetHashCode()),
            3 => first.UnionBy(second, y => y, EqualityComparer<int>.Default),
            _ => first.UnionBy(second, y => y)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
