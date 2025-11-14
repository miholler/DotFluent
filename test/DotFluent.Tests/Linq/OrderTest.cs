using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableOrderTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Order())
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Order((y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Order(Comparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x.Order(comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0], 0)]
    [TestCase(new int[0], new int[0], 1)]
    [TestCase(new int[0], new int[0], 2)]
    [TestCase(new[] { 3, 1, 2 }, new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 3, 1, 2 }, new[] { 1, 2, 3 }, 1)]
    [TestCase(new[] { 3, 1, 2 }, new[] { 1, 2, 3 }, 2)]
    public void Order(IEnumerable<int> source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.Order(Comparer<int>.Default.Compare),
            2 => source.Order(Comparer<int>.Default),
            _ => source.Order()
        };
        result.ShouldBe(expectedResult);
    }
}
