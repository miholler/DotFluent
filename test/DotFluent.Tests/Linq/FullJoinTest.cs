using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableFullJoinTest
{
    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void OuterOrInnerNullThrowsException(IEnumerable<int> outer, IEnumerable<int> inner)
    {
        outer
            .Invoking(x => x.FullJoin(inner, y => y, (o, i) => new { Outer = o, Inner = i }))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z, x => x.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, (o, i) => new { Outer = o, Inner = i }))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        outer
            .Invoking(x => x.FullJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, keySelector, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void OuterKeySelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        outer
            .Invoking(x => x.FullJoin(inner, keySelector, y => y, (o, i) => new { Outer = o, Inner = i }))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, keySelector, y => y, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, keySelector, y => y, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, keySelector, y => y, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void InnerKeySelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        outer
            .Invoking(x => x.FullJoin(inner, y => y, keySelector, (o, i) => new { Outer = o, Inner = i }))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, keySelector, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, keySelector, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, keySelector, (o, i) => new { Outer = o, Inner = i }, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ResultSelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int, int> resultSelector = null;

        outer
            .Invoking(x => x.FullJoin(inner, y => y, resultSelector))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, resultSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, resultSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, resultSelector, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, resultSelector))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, resultSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, resultSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, resultSelector, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        outer
            .Invoking(x => x.FullJoin(inner, y => y, (o, i) => new { Outer = o, Inner = i }, comparison))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, (o, i) => new { Outer = o, Inner = i }, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, (o, i) => new { Outer = o, Inner = i }, comparison))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, (o, i) => new { Outer = o, Inner = i }, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        outer
            .Invoking(x => x.FullJoin(inner, y => y, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        outer
            .Invoking(x => x.FullJoin(inner, y => y, y => y, (o, i) => new { Outer = o, Inner = i }, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    public void FullJoin([Values(0, 1, 2, 3, 4, 5, 6, 7)]int overload)
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 2, Name: "B");
        var c = (Id: 3, Name: "C");
        var d = (Id: 4, Name: "D");
        var outer = Enumerable.Create(a, b, c);
        var inner = Enumerable.Create(b, b, d);

        var result = overload switch
        {
            1 => outer.FullJoin(inner, x => x.Id, (o, i) => (o, i), (x, y) => x == y),
            2 => outer.FullJoin(inner, x => x.Id, (o, i) => (o, i), (x, y) => x == y, x => x.GetHashCode()),
            3 => outer.FullJoin(inner, x => x.Id, (o, i) => (o, i), EqualityComparer<int>.Default),
            4 => outer.FullJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i)),
            5 => outer.FullJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), (x, y) => x == y),
            6 => outer.FullJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), (x, y) => x == y, x => x.GetHashCode()),    
            7 => outer.FullJoin(inner, x => x.Id, x => x.Id, (o, i) => (o, i), EqualityComparer<int>.Default),
            _ => outer.FullJoin(inner, x => x.Id, (o, i) => (o, i))
        };
        result.ShouldBe([
            (a, default),
            (b, b),
            (b, b),
            (c, default),
            (default, d)]);
    }
}
