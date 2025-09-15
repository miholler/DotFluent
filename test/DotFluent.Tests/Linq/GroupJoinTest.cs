using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableGroupJoinTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void OuterOrInnerNullThrowsException(IEnumerable<int> outer, IEnumerable<int> inner)
    {
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, (o, ie) => new { Outer = o, Inners = ie }))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, (o, ie) => new { Outer = o, Inners = ie }, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        outer
            .Invoking(x => x.GroupJoin(inner, keySelector, (o, ie) => new { Outer = o, Inners = ie }))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, keySelector, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, keySelector, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, keySelector, (o, ie) => new { Outer = o, Inners = ie }, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void OuterKeySelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        outer
            .Invoking(x => x.GroupJoin(inner, keySelector, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, keySelector, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void InnerKeySelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        outer
            .Invoking(x => x.GroupJoin(inner, y => y, keySelector, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, keySelector, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ResultSelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, IEnumerable<int>, int> resultSelector = null;

        outer
            .Invoking(x => x.GroupJoin(inner, y => y, resultSelector))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, resultSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, resultSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, resultSelector, EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, resultSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, resultSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        outer
            .Invoking(x => x.GroupJoin(inner, y => y, (o, ie) => new { Outer = o, Inners = ie }, comparison))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, (o, ie) => new { Outer = o, Inners = ie }, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, comparison))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        outer
            .Invoking(x => x.GroupJoin(inner, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public void GroupJoin(int overload)
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 2, Name: "B");
        var c = (Id: 3, Name: "C");
        var d = (Id: 4, Name: "D");
        var outer = Sequence.Create(a, b, c);
        var inner = Sequence.Create(b, b, d);

        var result = overload switch
        {
            1 => outer.GroupJoin(inner, x => x.Id, (o, ie) => (o, ie.Count(x => x.Id == o.Id)), (x, y) => x == y),
            2 => outer.GroupJoin(inner, x => x.Id, (o, ie) => (o, ie.Count(x => x.Id == o.Id)), (x, y) => x == y, x => x.GetHashCode()),
            3 => outer.GroupJoin(inner, x => x.Id, (o, ie) => (o, ie.Count(x => x.Id == o.Id)), EqualityComparer<int>.Default),
            4 => outer.GroupJoin(inner, x => x.Id, x => x.Id, (o, ie) => (o, ie.Count(x => x.Id == o.Id)), (x, y) => x == y),
            5 => outer.GroupJoin(inner, x => x.Id, x => x.Id, (o, ie) => (o, ie.Count(x => x.Id == o.Id)), (x, y) => x == y, x => x.GetHashCode()),
            _ => outer.GroupJoin(inner, x => x.Id, (o, ie) => (o, ie.Count(x => x.Id == o.Id)))
        };
        result.ShouldBe([
            (a, default),
            (b, 2),
            (c, default)]);
    }

    #endregion
}
