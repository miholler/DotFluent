using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableElementAtOrDefaultTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.ElementAtOrDefault(0, 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ElementAtOrDefault(0, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void DefaultFactoryNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int> defaultFactory = null;

        source
            .Invoking(x => x.ElementAtOrDefault(0, defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0, 0, 0)]
    [TestCase(new int[0], 0, 0, 1, 0)]
    [TestCase(new int[0], 0, 0, 0, 1)]
    [TestCase(new int[0], 0, 0, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, -3, 0, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, -3, 0, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, -3, 0, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, -3, 0, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 1, 1)]
    public void ElementAtOrDefault(IEnumerable<int> source, int index, int expectedResult, int collectionType, int overload)
    {
        source = collectionType switch
        {
            1 => source
                .ToImmutableHashSet()
                .AsEnumerable(),
            _ => source
                .ToImmutableArray()
                .AsEnumerable()
        };
        var result = overload switch
        {
            1 => source.ElementAtOrDefault(index, () => 0),
            _ => source.ElementAtOrDefault(index, 0)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
