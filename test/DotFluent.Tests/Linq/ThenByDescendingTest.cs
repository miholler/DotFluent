using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableThenByDescendingTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IOrderedEnumerable<int> source = null;

        source
            .Invoking(x => x.ThenByDescending(y => y, (y, z) => 0))
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
                .ThenByDescending(keySelector, (y, z) => 0))
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
                .ThenByDescending(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ThenByDescending()
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 1, Name: "B");
        var c = (Id: 2, Name: "C");
        var d = (Id: 2, Name: "D");
        var source = Sequence.Create(a, c, b, d);

        source
            .OrderBy(x => x.Id)
            .ThenByDescending(x => x.Name, StringComparer.Ordinal.Compare)
            .ShouldBe([b, a, d, c]);
    }
}
