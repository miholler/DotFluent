using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class SingleOrDefaultTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.SingleOrDefault(() => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.SingleOrDefault(y => y == 0, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void DefaultFactoryNullThrowsExceotion()
    {
        var source = Enumerable.Empty<int>();
        Func<int> defaultFactory = null;

        source
            .Invoking(x => x.SingleOrDefault(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.SingleOrDefault(y => y == 0, defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, bool> predicate = null;

        source
            .Invoking(x => x.SingleOrDefault(predicate, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new[] { 1, 2, 3, 4 }, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1)]
    public void MultipleElementsThrowsException(IEnumerable<int> source, int collectionType)
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

        source
            .Invoking(x => x.SingleOrDefault(() => 0))
            .ShouldThrow<InvalidOperationException>();
        source
            .Invoking(x => x.SingleOrDefault(x => x % 2 == 0, () => 0))
            .ShouldThrow<InvalidOperationException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0, 0)]
    [TestCase(new int[0], 0, 1, 0)]
    [TestCase(new int[0], 0, 0, 1)]
    [TestCase(new int[0], 0, 1, 1)]
    [TestCase(new[] { 1 }, 1, 0, 0)]
    [TestCase(new[] { 1 }, 1, 1, 0)]
    [TestCase(new[] { 1 }, 0, 0, 1)]
    [TestCase(new[] { 1 }, 0, 1, 1)]
    [TestCase(new[] { 1, 3, 5 }, 0, 0, 1)]
    [TestCase(new[] { 1, 3, 5 }, 0, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 1)]
    public void SingleOrDefault(IEnumerable<int> source, int expectedResult, int collectionType, int overload)
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
            1 => source.SingleOrDefault(x => x % 2 == 0, () => 0),
            _ => source.SingleOrDefault(() => 0)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
