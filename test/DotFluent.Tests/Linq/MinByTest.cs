using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableMinByTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.MinBy(y => y, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SourceEmptyThrowsException()
    {
        var source = Enumerable.Empty<int>();

        source
            .Invoking(x => x.MinBy(y => y, (y, z) => 0))
            .ShouldThrow<InvalidOperationException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.MinBy(keySelector, (y, z) => 0))
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
    [TestCase(new string[0], null)]
    [TestCase(new string[] { null, null, null }, null)]
    [TestCase(new[] { "A" }, "A")]
    [TestCase(new[] { "C", "A", "B" }, "A")]
    [TestCase(new[] { null, "B", null }, "B")]
    public void ReferenceTypeMinBy(IEnumerable<string> source, string expectedResult)
        => source
            .MinBy(x => x, StringComparer.Ordinal.Compare)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { 3, 1, 2 }, 1)]
    public void ValueTypeMinBy(IEnumerable<int> source, int expectedResult)
        => source
            .MinBy(x => x, Comparer<int>.Default.Compare)
            .ShouldBe(expectedResult);

    #endregion
}
