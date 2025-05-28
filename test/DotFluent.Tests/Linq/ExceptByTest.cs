using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableExceptByTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void FirstOrSecondNullThrowsException(IEnumerable<int> first, IEnumerable<int> second)
    {
        first
            .Invoking(x => x.ExceptBy(second, y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.ExceptBy(second, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        first
            .Invoking(x => x.ExceptBy(second, keySelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.ExceptBy(second, keySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        first
            .Invoking(x => x.ExceptBy(second, y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.ExceptBy(second, y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        first
            .Invoking(x => x.ExceptBy(second, y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new int[0], new int[0], new int[0], 0)]
    [TestCase(new int[0], new int[0], new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new int[0], 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 1, 2, 3 }, 1)]
    public void ExceptBy(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => first.ExceptBy(second, x => x, (x, y) => x == y, x => x.GetHashCode()),
            _ => first.ExceptBy(second, x => x, (x, y) => x == y)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
