using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class ForEachTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.ForEach(y => y++))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ForEach((y, i) => y += i))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ActionNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Action<int> action = null;
        Action<int, int> indexAction = null;

        source
            .Invoking(x => x.ForEach(action))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.ForEach(indexAction))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0)]
    [TestCase(new int[0], 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 6, 0)]
    [TestCase(new[] { 1, 2, 3 }, 9, 1)]
    public void ForEach(IEnumerable<int> source, int expectedResult, int overload)
    {
        var result = 0;
        switch (overload)
        {
            case 1:
                source.ForEach((x, i) => result += x + i);
                break;
            default:
                source.ForEach(x => result += x);
                break;
        }

        result.ShouldBe(expectedResult);
    }

    #endregion
}
