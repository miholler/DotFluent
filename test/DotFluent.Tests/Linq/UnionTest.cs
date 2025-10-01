using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableUnionTest
{
    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void FirstOrSecondNullThrowsException(IEnumerable<int> first, IEnumerable<int> second)
    {
        first
            .Invoking(x => x.Union(second, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.Union(second, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        first
            .Invoking(x => x.Union(second, comparison))
            .ShouldThrow<ArgumentNullException>();
        first
            .Invoking(x => x.Union(second, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var first = Enumerable.Empty<int>();
        var second = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        first
            .Invoking(x => x.Union(second, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new int[0], new int[0], new int[0], 0)]
    [TestCase(new int[0], new int[0], new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 1, 2, 3, 4 }, 1)]
    public void Union(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => first.Union(second, (x, y) => x == y, x => x.GetHashCode()),
            _ => first.Union(second, (x, y) => x == y)
        };

        result.ShouldBe(expectedResult);
    }
}
