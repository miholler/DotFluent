using NUnit.Framework;
using Shouldly;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableNoneTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.None())
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.None(_ => false))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, bool> predicate = null;

        source
            .Invoking(x => x.None(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], true, 0, 0)]
    [TestCase(new int[0], true, 1, 0)]
    [TestCase(new int[0], true, 2, 0)]
    [TestCase(new int[0], true, 0, 1)]
    [TestCase(new int[0], true, 1, 1)]
    [TestCase(new int[0], true, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, false, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, false, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, false, 2, 0)]
    [TestCase(new[] { 1, 2, 3 }, false, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, false, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, false, 2, 1)]
    public void None(IEnumerable<int> source, bool expectedResult, int collectionType, int overload)
    {
        source = collectionType switch
        {
            1 => new ConcurrentQueue<int>(source),
            2 => source.AsIterator(),
            _ => source
                .ToImmutableArray()
                .AsEnumerable()
        };
        var result = overload switch
        {
            1 => source.None(x => x % 2 == 0),
            _ => source.None()
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
