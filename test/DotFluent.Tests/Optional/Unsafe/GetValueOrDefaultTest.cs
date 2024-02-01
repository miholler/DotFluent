using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent.Optional.Unsafe;

[TestFixture]
public sealed class OptionGetValueOrDefaultTest
{
    #region Methods

    [Test]
    public void DefaultFactoryNullThrowsExcption()
    {
        var option = Option.None<int>();
        Func<int> defaultFactory = null;

        option
            .Invoking(x => x.GetValueOrDefault(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 0)]
    [TestCase(1, 1)]
    public void GetValueOrDefault(int? source, int expectedResult)
        => source
            .ToOption()
            .GetValueOrDefault()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(null, 1, 1, 0)]
    [TestCase(1, 2, 1, 0)]
    [TestCase(null, 1, 1, 1)]
    [TestCase(1, 2, 1, 1)]
    public void GetValueOrDefaultWithDefaultValue(int? source, int defaultValue, int expectedResult, int overload)
    {
        var option = source.ToOption();
        var result = overload switch
        {
            1 => option.GetValueOrDefault(() => defaultValue),
            _ => option.GetValueOrDefault(defaultValue)
        };

        result.ShouldBe(expectedResult);
    }

    #endregion
}

[TestFixture]
public sealed class ResultGetValueOrDefaultTest
{
    #region Methods

    [Test]
    public void DefaultFactoryNullThrowsExcption()
    {
        var result = Result.Error<int>(new());
        Func<int> defaultFactory = null;

        result
            .Invoking(x => x.GetValueOrDefault(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1)]
    [TestCase(null, 0)]
    public void GetValueOrDefault(int? source, int expectedResult)
        => source
            .Match(Result.Ok, () => Result.Error<int>(new()))
            .GetValueOrDefault()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(1, 2, 1, 0)]
    [TestCase(null, 1, 1, 0)]
    [TestCase(1, 2, 1, 1)]
    [TestCase(null, 1, 1, 1)]
    public void GetValueOrDefaultWithDefaultValue(int? source, int defaultValue, int expectedResult, int overload)
    {
        var result = source.Match(Result.Ok, () => Result.Error<int>(new()));
        var currentResult = overload switch
        {
            1 => result.GetValueOrDefault(() => defaultValue),
            _ => result.GetValueOrDefault(defaultValue)
        };

        currentResult.ShouldBe(expectedResult);
    }

    #endregion
}
