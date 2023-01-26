using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class OrderByTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.OrderBy(y => y, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.OrderBy(keySelector, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x.OrderBy(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
    public void OrderBy(IEnumerable<int> source, IEnumerable<int> expectedResult)
        => source
            .OrderBy(x => x, Comparer<int>.Default.Compare)
            .ShouldBe(expectedResult);

    #endregion
}
