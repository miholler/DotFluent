using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Optional.Linq;

[TestFixture]
public sealed class OptionSelectTest
{
    #region Methods

    [Test]
    public void SelectorNullThrowsException()
    {
        var option = Option.None<int>();
        Func<int, int> selector = null;

        option
            .Invoking(x => x.Select(selector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public void Select(int? source, IEnumerable<int> expectedResult)
    {
        var result = from x in source.ToOption()
                     select x;

        result.ShouldBe(expectedResult);
    }

    #endregion
}

[TestFixture]
public sealed class ResultSelectTest
{
    #region Methods

    [Test]
    public void SelectorNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        Func<int, int> selector = null;

        result
            .Invoking(x => x.Select(selector))
            .ShouldThrow<ArgumentNullException>();
        result2
            .Invoking(x => x.Select(selector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    public void Select(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => (from x in source.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                  select x).AsEnumerable(),
            _ => (from x in source.Match(Result.Ok, () => Result.Error<int>(new()))
                  select x).AsEnumerable()
        };

        currentResult.ShouldBe(expectedResult);
    }

    #endregion
}
