using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableInsertTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Insert(0, 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], -1, 0)]
    [TestCase(new[] { 1, 2 }, 3, 0)]
    public void IndexOutOfRangeThrowsException(IEnumerable<int> source, int index, int item)
        => source
            .Invoking(x => x
                .Insert(index, item)
                .ToImmutableArray())
            .ShouldThrow<ArgumentOutOfRangeException>();

    [Test]
    [TestCase(new int[0], 0, 1, new[] { 1 })]
    [TestCase(new[] { 1, 3 }, 1, 2, new[] { 1, 2, 3 })]
    public void Insert(IEnumerable<int> source, int index, int item, IEnumerable<int> expectedResult)
        => source
            .Insert(index, item)
            .ShouldBe(expectedResult);

    #endregion
}
