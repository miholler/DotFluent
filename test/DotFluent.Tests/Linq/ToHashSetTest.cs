using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableToHashSetTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.ToHashSet((y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToHashSet((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.ToHashSet(comparison))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ToHashSet(comparison, y => y.GetHashCode()))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void HashCodeSelectorNullDoesNotThrowException()
    {
        var source = Enumerable.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        source
            .Invoking(x => x.ToHashSet((y, z) => y == z, hashCodeSelector))
            .ShouldNotThrow();
    }

    [Test]
    [TestCase(new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1)]
    public void ToHashSet(IEnumerable<int> source, int overload)
    {
        var result = overload switch
        {
            1 => source.ToHashSet((x, y) => x == y, x => x.GetHashCode()),
            _ => source.ToHashSet((x, y) => x == y)
        };
        result.ShouldBe(new HashSet<int>(source));
    }

    #endregion
}
