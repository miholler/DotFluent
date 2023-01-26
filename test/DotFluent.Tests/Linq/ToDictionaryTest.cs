using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class ToDictionaryTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.ToDictionary(y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(y => y, y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(y => y, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.ToDictionary(keySelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(keySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(keySelector, y => y, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(keySelector, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ElementSelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> elementSelector = null;

        source
            .Invoking(x => x.ToDictionary(y => y, elementSelector, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(y => y, elementSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.ToDictionary(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(y => y, y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(y => y, y => y, comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> hashCodeSelector = null;

        source
            .Invoking(x => x.ToDictionary(y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToDictionary(y => y, y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void ToDictionary(int overload)
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 2, Name: "B");
        var c = (Id: 3, Name: "C");
        var source = Sequence.Create(a, b, c);

        var result = overload switch
        {
            1 => source.ToDictionary(x => x.Id, (x, y) => x == y, x => x.GetHashCode()),
            2 => source.ToDictionary(x => x.Id, x => x, (x, y) => x == y),
            3 => source.ToDictionary(x => x.Id, x => x, (x, y) => x == y, x => x.GetHashCode()),
            _ => source.ToDictionary(x => x.Id, (x, y) => x == y)
        };
        result.ShouldBe(
            new KeyValuePair<int, (int Id, string Name)>(a.Id, a),
            new KeyValuePair<int, (int Id, string Name)>(b.Id, b),
            new KeyValuePair<int, (int Id, string Name)>(c.Id, c));
    }

    #endregion
}
