using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class OrderByDescendingTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.OrderByDescending(y => y, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void KeySelectorNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, int> keySelector = null;

        source
            .Invoking(x => x.OrderByDescending(keySelector, (y, z) => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ComparisonNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Comparison<int> comparison = null;

        source
            .Invoking(x => x.OrderByDescending(y => y, comparison))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
    public void OrderByDescending(IEnumerable<int> source, IEnumerable<int> expectedResult)
        => source
            .OrderByDescending(x => x, Comparer<int>.Default.Compare)
            .ShouldBe(expectedResult);

    #endregion
}
