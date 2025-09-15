using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableMaxByTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.MaxBy(y => y, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SourceEmptyThrowsException()
    {
        var source = Enumerable.Empty<int>();

        source
            .Invoking(x => x.MaxBy(y => y, (y, z) => 0))
            .ShouldThrow<InvalidOperationException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.MaxBy(keySelector, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x.MaxBy(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new string[0], null)]
    [TestCase(new string[] { null, null, null }, null)]
    [TestCase(new[] { "A" }, "A")]
    [TestCase(new[] { "A", "C", "B" }, "C")]
    [TestCase(new[] { null, "B", null }, "B")]
    public void ReferenceTypeMaxBy(IEnumerable<string> source, string expectedResult)
        => source
            .MaxBy(x => x, StringComparer.Ordinal.Compare)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { 1, 3, 2 }, 3)]
    public void ValueTypeMaxBy(IEnumerable<int> source, int expectedResult)
        => source
            .MaxBy(x => x, Comparer<int>.Default.Compare)
            .ShouldBe(expectedResult);

    #endregion
}
