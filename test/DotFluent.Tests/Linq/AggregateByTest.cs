using NUnit.Framework;
using Shouldly;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableAggregateByTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.AggregateBy(y => y, 0, (y, z) => y + z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, 0, (y, z) => y + z, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, 0, (y, z) => y + z, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, 0, (y, z) => y + z, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, (y, z) => y + z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, (y, z) => y + z, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, (y, z) => y + z, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, (y, z) => y + z, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.AggregateBy(keySelector, 0, (y, z) => y + z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(keySelector, 0, (y, z) => y + z, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(keySelector, 0, (y, z) => y + z, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(keySelector, 0, (y, z) => y + z, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(keySelector, y => y, (y, z) => y + z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(keySelector, y => y, (y, z) => y + z, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(keySelector, y => y, (y, z) => y + z, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(keySelector, y => y, (y, z) => y + z, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SeedSelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> seedSelector = null;

        source
            .Invoking(x => x.AggregateBy(y => y, seedSelector, (y, z) => y + z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, seedSelector, (y, z) => y + z, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, seedSelector, (y, z) => y + z, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, seedSelector, (y, z) => y + z, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void FuncNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int, int> func = null;

        source
            .Invoking(x => x.AggregateBy(y => y, 0, func))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, 0, func, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, 0, func, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, 0, func, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, func))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, func, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, func, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, func, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.AggregateBy(y => y, 0, (y, z) => y + z, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, 0, (y, z) => y + z, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, (y, z) => y + z, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, (y, z) => y + z, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        source
            .Invoking(x => x.AggregateBy(y => y, 0, (y, z) => y + z, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        source
            .Invoking(x => x.AggregateBy(y => y, y => y, (y, z) => y + z, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new int[0], 1, 0)]
    [TestCase(new int[0], 1, 1)]
    [TestCase(new int[0], 1, 2)]
    [TestCase(new int[0], 1, 3)]
    [TestCase(new int[0], 1, 4)]
    [TestCase(new int[0], 1, 5)]
    [TestCase(new int[0], 1, 6)]
    [TestCase(new int[0], 1, 7)]
    [TestCase(new[] { 1, 2, 1 }, 1, 0)]
    [TestCase(new[] { 1, 2, 1 }, 1, 1)]
    [TestCase(new[] { 1, 2, 1 }, 1, 2)]
    [TestCase(new[] { 1, 2, 1 }, 1, 3)]
    [TestCase(new[] { 1, 2, 1 }, 1, 4)]
    [TestCase(new[] { 1, 2, 1 }, 1, 5)]
    [TestCase(new[] { 1, 2, 1 }, 1, 6)]
    [TestCase(new[] { 1, 2, 1 }, 1, 7)]
    public void AggregateBy(IEnumerable<int> source, int seed, int overload)
    {
        var result = overload switch
        {
            1 => source.AggregateBy(x => x, seed, (x, y) => x + y, (x, y) => x == y),
            2 => source.AggregateBy(x => x, seed, (x, y) => x + y, (x, y) => x == y, x => x.GetHashCode()),
            3 => source.AggregateBy(x => x, seed, (x, y) => x + y, EqualityComparer<int>.Default),
            4 => source.AggregateBy(x => x, _ => seed, (x, y) => x + y),
            5 => source.AggregateBy(x => x, _ => seed, (x, y) => x + y, (x, y) => x == y),
            6 => source.AggregateBy(x => x, _ => seed, (x, y) => x + y, (x, y) => x == y, x => x.GetHashCode()),
            7 => source.AggregateBy(x => x, _ => seed, (x, y) => x + y, EqualityComparer<int>.Default),
            _ => source.AggregateBy(x => x, seed, (x, y) => x + y)
        };
        var expectedResult = source
            .GroupBy(x => x, (k, ie) => new KeyValuePair<int, int>(k, seed + ie.Sum()))
            .ToImmutableArray();

        result.ShouldBe(expectedResult);
    }
}
