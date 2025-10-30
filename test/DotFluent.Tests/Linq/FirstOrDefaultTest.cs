using NUnit.Framework;
using Shouldly;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableFirstOrDefaultTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.FirstOrDefault(0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.FirstOrDefault(() => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.FirstOrDefault(y => y == 0, 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.FirstOrDefault(y => y == 0, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void DefaultFactoryNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int> defaultFactory = null;

        source
            .Invoking(x => x.FirstOrDefault(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.FirstOrDefault(y => y == 0, defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, bool> predicate = null;

        source
            .Invoking(x => x.FirstOrDefault(predicate, 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.FirstOrDefault(predicate, () => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0, 0)]
    [TestCase(new int[0], 0, 1, 0)]
    [TestCase(new int[0], 0, 0, 1)]
    [TestCase(new int[0], 0, 1, 1)]
    [TestCase(new int[0], 0, 0, 2)]
    [TestCase(new int[0], 0, 1, 2)]
    [TestCase(new int[0], 0, 0, 3)]
    [TestCase(new int[0], 0, 1, 3)]
    [TestCase(new[] { 1, 2, 3 }, 1, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 1, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 0, 2)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 2)]
    [TestCase(new[] { 1, 2, 3 }, 2, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 3)]
    public void FirstOrDefault(IEnumerable<int> source, int expectedResult, int collectionType, int overload)
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
            1 => source.FirstOrDefault(() => 0),
            2 => source.FirstOrDefault(x => x % 2 == 0, 0),
            3 => source.FirstOrDefault(x => x % 2 == 0, () => 0),
            _ => source.FirstOrDefault(0)
        };

        result.ShouldBe(expectedResult);
    }
}
