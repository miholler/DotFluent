using NUnit.Framework;
using Shouldly;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableLastOrDefaultTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.LastOrDefault(() => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.LastOrDefault(y => y == 0, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void DefaultFactoryNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int> defaultFactory = null;

        source
            .Invoking(x => x.LastOrDefault(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.LastOrDefault(y => y == 0, defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, bool> predicate = null;

        source
            .Invoking(x => x.LastOrDefault(predicate, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0, 0)]
    [TestCase(new int[0], 0, 1, 0)]
    [TestCase(new int[0], 0, 0, 1)]
    [TestCase(new int[0], 0, 1, 1)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 0, 0)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 1, 0)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, 0, 1)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, 1, 1)]
    public void LastOrDefault(IEnumerable<int> source, int expectedResult, int collectionType, int overload)
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
            1 => source.LastOrDefault(x => x % 2 == 0, () => 0),
            _ => source.LastOrDefault(() => 0)
        };

        result.ShouldBe(expectedResult);
    }
}
