using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Optional.Linq;

[TestFixture]
public sealed class OptionSelectManyTest
{
    #region Methods

    [Test]
    public void SelectorNullThrowsException()
    {
        var option = Option.None<int>();
        Func<int, Option<int>> selector = null;

        option
            .Invoking(x => x.SelectMany(selector))
            .ShouldThrow<ArgumentNullException>();
        option
            .Invoking(x => x.SelectMany(selector, (y, z) => y + z))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ResultSelectorNullThrowsException()
    {
        var option = Option.None<int>();
        Func<int, int, int> resultSelector = null;

        option
            .Invoking(x => x.SelectMany(Option.Some, resultSelector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public void SelectMany(int? source, IEnumerable<int> expectedResult)
        => source
            .ToOption()
            .SelectMany(Option.Some)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(null, null, new int[0])]
    [TestCase(null, 1, new int[0])]
    [TestCase(1, null, new int[0])]
    [TestCase(1, 1, new[] { 2 })]
    public void SelectManyWithResultSelector(int? source, int? selectorResult, IEnumerable<int> expectedResult)
    {
        var result = from x in source.ToOption()
                     from y in selectorResult.ToOption()
                     select x + y;

        result.ShouldBe(expectedResult);
    }

    #endregion
}

[TestFixture]
public sealed class ResultSelectManyTest
{
    #region Methods

    [Test]
    public void SelectorNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        Func<int, Result<int>> selector = null;
        Func<int, Result<int, int>> selector2 = null;

        result
            .Invoking(x => x.SelectMany(selector))
            .ShouldThrow<ArgumentNullException>();
        result
            .Invoking(x => x.SelectMany(selector, (y, z) => y + z))
            .ShouldThrow<ArgumentNullException>();
        result2
            .Invoking(x => x.SelectMany(selector2))
            .ShouldThrow<ArgumentNullException>();
        result2
            .Invoking(x => x.SelectMany(selector2, (y, z) => y + z))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ResultSelectorNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        Func<int, int, int> resultSelector = null;

        result
            .Invoking(x => x.SelectMany(Result.Ok, resultSelector))
            .ShouldThrow<ArgumentNullException>();
        result2
            .Invoking(x => x.SelectMany(Result.Ok<int, int>, resultSelector))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    public void SelectMany(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .SelectMany(Result.Ok<int, int>)
                .AsEnumerable(),
            _ => source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .SelectMany(Result.Ok)
                .AsEnumerable()
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 1, new[] { 2 }, 0)]
    [TestCase(1, 1, new[] { 2 }, 1)]
    [TestCase(1, null, new int[0], 0)]
    [TestCase(1, null, new int[0], 1)]
    [TestCase(null, 1, new int[0], 0)]
    [TestCase(null, 1, new int[0], 1)]
    [TestCase(null, null, new int[0], 0)]
    [TestCase(null, null, new int[0], 1)]
    public void SelectManyWithResultSelector(int? source, int? selectorResult, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => (from x in source.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                  from y in selectorResult.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                  select x + y).AsEnumerable(),
            _ => (from x in source.Match(Result.Ok, () => Result.Error<int>(new()))
                  from y in selectorResult.Match(Result.Ok, () => Result.Error<int>(new()))
                  select x + y).AsEnumerable()
        };

        currentResult.ShouldBe(expectedResult);
    }

    #endregion
}
