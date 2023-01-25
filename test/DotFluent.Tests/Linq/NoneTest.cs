using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class NoneTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.None())
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.None(y => y == 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int, bool> predicate = null;

        source
            .Invoking(x => x.None(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], true, 0)]
    [TestCase(new int[0], true, 1)]
    [TestCase(new[] { 1, 2, 3 }, false, 0)]
    [TestCase(new[] { 1, 2, 3 }, false, 1)]
    public void None(IEnumerable<int> source, bool expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.None(x => x % 2 == 0),
            _ => source.None()
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}
