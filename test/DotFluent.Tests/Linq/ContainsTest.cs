using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class ContainsTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => source.Contains(0, (y, z) => y == z))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        EqualityComparison<int> comparison = null;

        source
            .Invoking(x => x.Contains(0, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, false)]
    [TestCase(new int[] { 1, 2, 3 }, 4, false)]
    [TestCase(new int[] { 1, 2, 3 }, 2, true)]
    public void Contains(IEnumerable<int> source, int value, bool expectedResult)
        => source
            .Contains(value, (x, y) => x == y)
            .ShouldBe(expectedResult);

    #endregion
}
