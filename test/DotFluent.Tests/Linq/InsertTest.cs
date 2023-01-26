using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class InsertTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void FirstOrSecondNullThrowsException(IEnumerable<int> first, IEnumerable<int> second)
        => first
            .Invoking(x => x.Insert(second, 0))
            .ShouldThrow<ArgumentNullException>();

    [Test]
    [TestCase(new int[0], new int[0], -1)]
    [TestCase(new[] { 1, 2 }, new int[0], 3)]
    public void IndexOutOfRangeThrowsException(IEnumerable<int> first, IEnumerable<int> second, int index)
        => first
            .Invoking(x => x
                .Insert(second, index)
                .ToImmutableArray())
            .ShouldThrow<ArgumentOutOfRangeException>();

    [Test]
    [TestCase(new int[0], new int[0], 0, new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new int[0], 0, new[] { 1, 2, 3 })]
    [TestCase(new int[0], new[] { 1, 2, 3 }, 0, new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 4 }, new[] { 2, 3 }, 1, new[] { 1, 2, 3, 4 })]
    public void Insert(IEnumerable<int> first, IEnumerable<int> second, int index, IEnumerable<int> expectedResult)
        => first
            .Insert(second, index)
            .ShouldBe(expectedResult);

    #endregion
}
