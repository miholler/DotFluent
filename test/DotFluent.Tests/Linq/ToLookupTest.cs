using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableToLookupTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.ToLookup(y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(y => y, y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(y => y, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.ToLookup(keySelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(keySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(keySelector, y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(keySelector, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ElementSelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> elementSelector = null;

        source
            .Invoking(x => x.ToLookup(y => y, elementSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(y => y, elementSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.ToLookup(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(y => y, y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToLookup(y => y, y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        source
            .Invoking(x => x.ToLookup(y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        source
            .Invoking(x => x.ToLookup(y => y, y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void ToLookup(int overload)
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 2, Name: "B");
        var c = (Id: 3, Name: "C");
        var source = Enumerable.Create(a, b, c);

        var result = overload switch
        {
            1 => source.ToLookup(x => x.Id, (x, y) => x == y, x => x.GetHashCode()),
            2 => source.ToLookup(x => x.Id, x => x, (x, y) => x == y),
            3 => source.ToLookup(x => x.Id, x => x, (x, y) => x == y, x => x.GetHashCode()),
            _ => source.ToLookup(x => x.Id, (x, y) => x == y)
        };
        result.ShouldBe(source.GroupBy(x => x.Id));
    }
}
