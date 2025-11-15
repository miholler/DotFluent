using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableOrderDescendingTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.OrderDescending())
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.OrderDescending((y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.OrderDescending(Comparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x.OrderDescending(comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0], 0)]
    [TestCase(new int[0], new int[0], 1)]
    [TestCase(new int[0], new int[0], 2)]
    [TestCase(new[] { 1, 3, 2 }, new[] { 3, 2, 1 }, 0)]
    [TestCase(new[] { 1, 3, 2 }, new[] { 3, 2, 1 }, 1)]
    [TestCase(new[] { 1, 3, 2 }, new[] { 3, 2, 1 }, 2)]
    public void OrderDescending(IEnumerable<int> source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.OrderDescending(Comparer<int>.Default.Compare),
            2 => source.OrderDescending(Comparer<int>.Default),
            _ => source.OrderDescending()
        };
        result.ShouldBe(expectedResult);
    }
}
