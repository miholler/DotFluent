using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableMinByTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.MinBy(y => y))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.MinBy(y => y, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.MinBy(y => y, Comparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SourceEmptyThrowsException()
    {
        var source = Enumerable.Empty<int>();

        source
            .Invoking(x => x.MinBy(y => y))
            .ShouldThrow<InvalidOperationException>();
        source
            .Invoking(x => x.MinBy(y => y, (y, z) => 0))
            .ShouldThrow<InvalidOperationException>();
        source
            .Invoking(x => x.MinBy(y => y, Comparer<int>.Default))
            .ShouldThrow<InvalidOperationException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.MinBy(keySelector))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.MinBy(keySelector, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.MinBy(keySelector, Comparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x.MinBy(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparerNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<object>();
        var comparer = default(IComparer<object>);

        source
            .Invoking(x => x.MinBy(y => y, comparer))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new string[0], null, 0)]
    [TestCase(new string[0], null, 1)]
    [TestCase(new string[0], null, 2)]
    [TestCase(new string[] { null, null, null }, null, 0)]
    [TestCase(new string[] { null, null, null }, null, 1)]
    [TestCase(new string[] { null, null, null }, null, 2)]
    [TestCase(new[] { "A" }, "A", 0)]
    [TestCase(new[] { "A" }, "A", 1)]
    [TestCase(new[] { "A" }, "A", 2)]
    [TestCase(new[] { "C", "A", "B" }, "A", 0)]
    [TestCase(new[] { "C", "A", "B" }, "A", 1)]
    [TestCase(new[] { "C", "A", "B" }, "A", 2)]
    [TestCase(new[] { null, "B", null }, "B", 0)]
    [TestCase(new[] { null, "B", null }, "B", 1)]
    [TestCase(new[] { null, "B", null }, "B", 2)]
    public void ReferenceTypeMinBy(IEnumerable<string> source, string expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.MinBy(x => x, StringComparer.Ordinal.Compare),
            2 => source.MinBy(x => x, StringComparer.Ordinal),
            _ => source.MinBy(x => x)
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(new[] { 1 }, 1, 0)]
    [TestCase(new[] { 1 }, 1, 1)]
    [TestCase(new[] { 1 }, 1, 2)]
    [TestCase(new[] { 3, 1, 2 }, 1, 0)]
    [TestCase(new[] { 3, 1, 2 }, 1, 1)]
    [TestCase(new[] { 3, 1, 2 }, 1, 2)]
    public void ValueTypeMinBy(IEnumerable<int> source, int expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.MinBy(x => x, Comparer<int>.Default.Compare),
            2 => source.MinBy(x => x, Comparer<int>.Default),
            _ => source.MinBy(x => x)
        };
        result.ShouldBe(expectedResult);
    }
}
