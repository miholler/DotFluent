using NUnit.Framework;
using Shouldly;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableIndexOfTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.IndexOf(0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.IndexOf(0, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.IndexOf(0, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.IndexOf(0, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, -1, 0, 0)]
    [TestCase(new int[0], 0, -1, 1, 0)]
    [TestCase(new int[0], 0, -1, 0, 1)]
    [TestCase(new int[0], 0, -1, 1, 1)]
    [TestCase(new int[0], 0, -1, 0, 2)]
    [TestCase(new int[0], 0, -1, 1, 2)]
    [TestCase(new int[0], 0, -1, 0, 3)]
    [TestCase(new int[0], 0, -1, 1, 3)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 0, 2)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 1, 2)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1, 1, 3)]
    [TestCase(new[] { 1, 2, 3, 2 }, 2, 1, 0, 0)]
    [TestCase(new[] { 1, 2, 3, 2 }, 2, 1, 1, 0)]
    [TestCase(new[] { 1, 2, 3, 2 }, 2, 1, 0, 1)]
    [TestCase(new[] { 1, 2, 3, 2 }, 2, 1, 1, 1)]
    [TestCase(new[] { 1, 2, 3, 2 }, 2, 1, 0, 2)]
    [TestCase(new[] { 1, 2, 3, 2 }, 2, 1, 1, 2)]
    [TestCase(new[] { 1, 2, 3, 2 }, 2, 1, 0, 3)]
    [TestCase(new[] { 1, 2, 3, 2 }, 2, 1, 1, 3)]
    public void IndexOf(IEnumerable<int> source, int value, int expectedResult, int collectionType, int overload)
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
            1 => source.IndexOf(value, (x, y) => x == y),
            2 => source.IndexOf(value, EqualityComparer<int>.Default),
            3 => source.IndexOf(value, default(IEqualityComparer<int>)),
            _ => source.IndexOf(value)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
