using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableGroupByTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.GroupBy(y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.GroupBy(keySelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(keySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(keySelector, y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(keySelector, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(keySelector, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(keySelector, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(keySelector, y => y, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(keySelector, y => y, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ElementSelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> elementSelector = null;

        source
            .Invoking(x => x.GroupBy(y => y, elementSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, elementSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, elementSelector, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, elementSelector, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ResultSelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, IEnumerable<int>, int> resultSelector = null;

        source
            .Invoking(x => x.GroupBy(y => y, resultSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, resultSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, resultSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, resultSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.GroupBy(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, (k, ie) => ie.FirstOrDefault(), comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, (k, ie) => ie.FirstOrDefault(), comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, (k, ie) => ie.FirstOrDefault(), comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, (k, ie) => ie.FirstOrDefault(), comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        source
            .Invoking(x => x.GroupBy(y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        source
            .Invoking(x => x.GroupBy(y => y, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        source
            .Invoking(x => x.GroupBy(y => y, y => y, (k, ie) => ie.FirstOrDefault(), (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    public void GroupBy(int overload)
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 2, Name: "B");
        var c = (Id: 3, Name: "C");
        var source = Sequence.Create(a, b, c, a);

        var result = overload switch
        {
            1 => source.GroupBy(x => x.Id, (x, y) => x == y, x => x.GetHashCode()),
            2 => source.GroupBy(x => x.Id, x => x, (x, y) => x == y),
            3 => source.GroupBy(x => x.Id, x => x, (x, y) => x == y, x => x.GetHashCode()),
            4 => source.GroupBy(x => x.Id, (k, ie) => ie, (x, y) => x == y),
            5 => source.GroupBy(x => x.Id, (k, ie) => ie, (x, y) => x == y, x => x.GetHashCode()),
            6 => source.GroupBy(x => x.Id, x => x, (k, ie) => ie, (x, y) => x == y),
            7 => source.GroupBy(x => x.Id, x => x, (k, ie) => ie, (x, y) => x == y, x => x.GetHashCode()),
            _ => source.GroupBy(x => x.Id, (x, y) => x == y)
        };
        result
            .Select(x => x.AsEnumerable())
            .ShouldBe([
                Sequence.Create(a, a),
                Sequence.Create(b),
                Sequence.Create(c)]);
    }

    #endregion
}
