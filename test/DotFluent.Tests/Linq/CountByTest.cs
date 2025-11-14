using NUnit.Framework;
using Shouldly;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableCountByTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.CountBy(y => y))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.CountBy(y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.CountBy(y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.CountBy(y => y, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.CountBy(keySelector))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.CountBy(keySelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.CountBy(keySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.CountBy(keySelector, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.CountBy(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.CountBy(y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        source
            .Invoking(x => x.CountBy(y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new int[0], 0)]
    [TestCase(new int[0], 1)]
    [TestCase(new int[0], 2)]
    [TestCase(new int[0], 3)]
    [TestCase(new[] { 1, 2, 1 }, 0)]
    [TestCase(new[] { 1, 2, 1 }, 1)]
    [TestCase(new[] { 1, 2, 1 }, 2)]
    [TestCase(new[] { 1, 2, 1 }, 3)]
    public void CountBy(IEnumerable<int> source, int overload)
    {
        var result = overload switch
        {
            1 => source.CountBy(x => x, (x, y) => x == y),
            2 => source.CountBy(x => x, (x, y) => x == y, x => x.GetHashCode()),
            3 => source.CountBy(x => x, EqualityComparer<int>.Default),
            _ => source.CountBy(x => x)
        };
        var expectedResult = source
            .GroupBy(x => x, (k, ie) => new KeyValuePair<int, int>(k, ie.Count()))
            .ToImmutableArray();

        result.ShouldBe(expectedResult);
    }
}
