using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableSequenceEqualTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void FirstOrSecondNullThrowsException(IEnumerable<int> first, IEnumerable<int> second)
        => first
            .Invoking(x => x.SequenceEqual(second, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();

    [Test]
    public void ComparisonNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        first
            .Invoking(x => x.SequenceEqual(second, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0], true)]
    [TestCase(new int[0], new[] { 1, 2, 3 }, false)]
    [TestCase(new[] { 1, 2, 3 }, new int[0], false)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 1 }, false)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, true)]
    public void SequenceEqual(IEnumerable<int> first, IEnumerable<int> second, bool expectedResult)
        => first
            .SequenceEqual(second, (x, y) => x == y)
            .ShouldBe(expectedResult);

    #endregion
}
