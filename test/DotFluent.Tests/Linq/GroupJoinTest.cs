using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class GroupJoinTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void OuterOrInnerNullThrowsException(IEnumerable<int> outer, IEnumerable<int> inner)
    {
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, y => y.GetHashCode()))
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
        Func<int, IEnumerable<int>, IEnumerable<int>> resultSelector = null;

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
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, comparison))
            .ShouldThrow<ArgumentNullException>();
        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullThrowsException()
    {
        var outer = Enumerable.Empty<int>();
        var inner = Enumerable.Empty<int>();
        Func<int, int> hashCodeSelector = null;

        outer
            .Invoking(x => x.GroupJoin(inner, y => y, y => y, (o, ie) => new { Outer = o, Inners = ie }, (y, z) => y == z, hashCodeSelector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
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
            1 => outer.GroupJoin(inner, x => x.Id, x => x.Id, (o, ie) => (o, ie.Count(x => x.Id == o.Id)), (x, y) => x == y, x => x.GetHashCode()),
            _ => outer.GroupJoin(inner, x => x.Id, x => x.Id, (o, ie) => (o, ie.Count(x => x.Id == o.Id)), (x, y) => x == y)
        };
        result.ShouldBe(
            (a, default),
            (b, 2),
            (c, default));
    }

    #endregion
}
