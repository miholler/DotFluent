using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableToDictionaryTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;
        IEnumerable<KeyValuePair<int, int>> pairSource = null;
        IEnumerable<ValueTuple<int, int>> tupleSource = null;

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
        pairSource
            .Invoking(x => x.ToDictionary())
            .ShouldThrow<ArgumentNullException>();
        pairSource
            .Invoking(x => x.ToDictionary((y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        pairSource
            .Invoking(x => x.ToDictionary((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        pairSource
            .Invoking(x => x.ToDictionary(EqualityComparer<int>.Default))
            .ShouldThrow<ArgumentNullException>();
        tupleSource
            .Invoking(x => x.ToDictionary())
            .ShouldThrow<ArgumentNullException>();
        tupleSource
            .Invoking(x => x.ToDictionary((y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        tupleSource
            .Invoking(x => x.ToDictionary((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        tupleSource
            .Invoking(x => x.ToDictionary(EqualityComparer<int>.Default))
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
        var pairSource = Enumerable.Empty<KeyValuePair<int, int>>();
        var tupleSource = Enumerable.Empty<ValueTuple<int, int>>();
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
        pairSource
            .Invoking(x => x.ToDictionary(comparison))
            .ShouldThrow<ArgumentNullException>();
        pairSource
            .Invoking(x => x.ToDictionary(comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
        tupleSource
            .Invoking(x => x.ToDictionary(comparison))
            .ShouldThrow<ArgumentNullException>();
        tupleSource
            .Invoking(x => x.ToDictionary(comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<int>();
        var pairSource = Enumerable.Empty<KeyValuePair<int, int>>();
        var tupleSource = Enumerable.Empty<ValueTuple<int, int>>();
        HashFunc<int> hashCodeSelector = null;

        source
            .Invoking(x => x.ToDictionary(y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        source
            .Invoking(x => x.ToDictionary(y => y, y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        pairSource
            .Invoking(x => x.ToDictionary((y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
        tupleSource
            .Invoking(x => x.ToDictionary((y, z) => y == z, hashCodeSelector))
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
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(11)]
    public void ToDictionary(int overload)
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 2, Name: "B");
        var c = (Id: 3, Name: "C");
        var source = Enumerable.Create(a, b, c);

        var result = overload switch
        {
            1 => source.ToDictionary(x => x.Id, (x, y) => x == y, x => x.GetHashCode()),
            2 => source.ToDictionary(x => x.Id, x => x, (x, y) => x == y),
            3 => source.ToDictionary(x => x.Id, x => x, (x, y) => x == y, x => x.GetHashCode()),
            4 => source.Select(x => new KeyValuePair<int, (int Id, string Name)>(x.Id, x)).ToDictionary(),
            5 => source.Select(x => new KeyValuePair<int, (int Id, string Name)>(x.Id, x)).ToDictionary((x, y) => x == y),
            6 => source.Select(x => new KeyValuePair<int, (int Id, string Name)>(x.Id, x)).ToDictionary((x, y) => x == y, x => x.GetHashCode()),
            7 => source.Select(x => new KeyValuePair<int, (int Id, string Name)>(x.Id, x)).ToDictionary(EqualityComparer<int>.Default),
            8 => source.Select(x => (x.Id, x)).ToDictionary(),
            9 => source.Select(x => (x.Id, x)).ToDictionary((x, y) => x == y),
            10 => source.Select(x => (x.Id, x)).ToDictionary((x, y) => x == y, x => x.GetHashCode()),
            11 => source.Select(x => (x.Id, x)).ToDictionary(EqualityComparer<int>.Default),
            _ => source.ToDictionary(x => x.Id, (x, y) => x == y)
        };
        result.ShouldBe(new Dictionary<int, (int Id, string Name)>()
        {
            { a.Id, a },
            { b.Id, b },
            { c.Id, c }
        });
    }
}
