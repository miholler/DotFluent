using NUnit.Framework;
using Shouldly;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableElementAtOrDefaultTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.ElementAtOrDefault(0, 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ElementAtOrDefault(Index.FromStart(0), 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ElementAtOrDefault(0, () => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ElementAtOrDefault(Index.FromStart(0), () => 0))
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
        source
            .Invoking(x => x.ElementAtOrDefault(Index.FromStart(0), defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0, 0, 0)]
    [TestCase(new int[0], 0, 0, 1, 0)]
    [TestCase(new int[0], 0, 0, 0, 1)]
    [TestCase(new int[0], 0, 0, 1, 1)]
    [TestCase(new int[0], -1, 0, 0, 1)]
    [TestCase(new int[0], -1, 0, 1, 1)]
    [TestCase(new int[0], 0, 0, 0, 2)]
    [TestCase(new int[0], 0, 0, 1, 2)]
    [TestCase(new int[0], 0, 0, 0, 3)]
    [TestCase(new int[0], 0, 0, 1, 3)]
    [TestCase(new int[0], -1, 0, 0, 3)]
    [TestCase(new int[0], -1, 0, 1, 3)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, -4, 0, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, -4, 0, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 0, 2)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 1, 2)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 1, 3)]
    [TestCase(new[] { 1, 2, 3 }, -4, 0, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, -4, 0, 1, 3)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, -2, 2, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, -2, 2, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 0, 2)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 1, 2)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 1, 3)]
    [TestCase(new[] { 1, 2, 3 }, -2, 2, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, -2, 2, 1, 3)]
    public void ElementAtOrDefault(IEnumerable<int> source, int index, int expectedResult, int collectionType, int overload)
    {
        source = collectionType switch
        {
            1 => source.AsIterator(),
            _ => source
                .ToImmutableArray()
                .AsEnumerable()
        };
        var i = index >= 0
            ? Index.FromStart(index)
            : Index.FromEnd(Math.Abs(index));
        var result = overload switch
        {
            1 => source.ElementAtOrDefault(i, 0),
            2 => source.ElementAtOrDefault(i.Value, () => 0),
            3 => source.ElementAtOrDefault(i, () => 0),
            _ => source.ElementAtOrDefault(i.Value, 0)
        };

        result.ShouldBe(expectedResult);
    }
}
