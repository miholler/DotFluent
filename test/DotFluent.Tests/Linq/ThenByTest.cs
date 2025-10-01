using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableThenByTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IOrderedEnumerable<int> source = null;

        source
            .Invoking(x => x.ThenBy(y => y, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x
                .OrderBy(y => y)
                .ThenBy(keySelector, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x
                .OrderBy(y => y)
                .ThenBy(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ThenBy()
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 1, Name: "B");
        var c = (Id: 2, Name: "C");
        var d = (Id: 2, Name: "D");
        var source = Sequence.Create(b, a, d, c);

        source
            .OrderBy(y => y.Id)
            .ThenBy(y => y.Name, StringComparer.Ordinal.Compare)
            .ShouldBe([a, b, c, d]);
    }
}
