using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableCrossJoinTest
{
    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void OuterOrInnerNullThrowsException(IEnumerable<int> outer, IEnumerable<int> inner)
    {
        outer
            .Invoking(x => x.CrossJoin(inner))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.CrossJoin(inner, (o, i) => (o, i)))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ResultSelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int, int> resultSelector = null;

        outer
            .Invoking(x => x.CrossJoin(inner, resultSelector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void CrossJoinEmptyOuterReturnsEmpty()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Create(1, 2, 3);

        outer
            .CrossJoin(inner)
            .ShouldBeEmpty();
        outer
            .CrossJoin(inner, (o, i) => (o, i))
            .ShouldBeEmpty();
    }

    [Test]
    public void CrossJoinEmptyInnerReturnsEmpty()
    {
        var outer = Enumerable.Create(1, 2, 3);
        var inner = Enumerable.Empty<string>();

        outer
            .CrossJoin(inner)
            .ShouldBeEmpty();
        outer
            .CrossJoin(inner, (o, i) => (o, i))
            .ShouldBeEmpty();
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public void CrossJoin(int overload)
    {
        var outer = Enumerable.Create(1, 2);
        var inner = Enumerable
            .Create("a", "b", "c")
            .AsIterator();

        var result = overload switch
        {
            1 => outer.CrossJoin(inner, (o, i) => (Outer: o, Inner: i)),
            _ => outer.CrossJoin(inner)
        };
        result.ShouldBe([
            (1, "a"),
            (1, "b"),
            (1, "c"),
            (2, "a"),
            (2, "b"),
            (2, "c")]);
    }
}
