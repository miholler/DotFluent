using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableMaxTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Max((y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SourceEmptyThrowsException()
    {
        var source = Enumerable.Empty<int>();

        source
            .Invoking(x => x.Max((y, z) => 0))
            .ShouldThrow<InvalidOperationException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x.Max(comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new string[0], null)]
    [TestCase(new string[] { null, null, null }, null)]
    [TestCase(new[] { "A" }, "A")]
    [TestCase(new[] { "A", "C", "B" }, "C")]
    [TestCase(new[] { null, "B", null }, "B")]
    public void ReferenceTypeMax(IEnumerable<string> source, string expectedResult)
        => source
            .Max(StringComparer.Ordinal.Compare)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { 1, 3, 2 }, 3)]
    public void ValueTypeMax(IEnumerable<int> source, int expectedResult)
        => source
            .Max(Comparer<int>.Default.Compare)
            .ShouldBe(expectedResult);

    #endregion
}
