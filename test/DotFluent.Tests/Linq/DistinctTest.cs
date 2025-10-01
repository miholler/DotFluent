using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableDistinctTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Distinct((y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Distinct((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.Distinct(comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Distinct(comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        source
            .Invoking(x => x.Distinct((y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new int[0], new int[0], 0)]
    [TestCase(new int[0], new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 1)]
    [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 }, 1)]
    public void Distinct(IEnumerable<int> source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.Distinct((x, y) => x == y, x => x.GetHashCode()),
            _ => source.Distinct((x, y) => x == y)
        };

        result.ShouldBe(expectedResult);
    }
}
