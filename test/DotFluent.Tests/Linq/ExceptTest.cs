using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class ExceptTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void FirstOrSecondNullThrowsException(IEnumerable<int> first, IEnumerable<int> second)
    {
        first
            .Invoking(x => x.Except(second, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.Except(second, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        first
            .Invoking(x => x.Except(second, comparison))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.Except(second, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        Func<int, int> hashCodeSelector = null;

        first
            .Invoking(x => x.Except(second, (y, z) => y == z, hashCodeSelector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0], new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 1, 2, 3 })]
    public void Except(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
        => first
            .Except(second, (x, y) => x == y)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(new int[0], new int[0], new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 1, 2, 3 })]
    public void ExceptWithHashCode(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
    {
        var hash = GetHashCode();

        first
            .Except(second, (x, y) => x == y, x => x.GetHashCode() ^ hash)
            .ShouldBe(expectedResult);
    }

    #endregion
}
