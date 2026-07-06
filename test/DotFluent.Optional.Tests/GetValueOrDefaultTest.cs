using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OptionGetValueOrDefaultTest
{
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
}

[TestFixture]
public sealed class ResultGetValueOrDefaultTest
{
    [Test]
    public void DefaultFactoryNullThrowsExcption()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        Func<int> defaultFactory = null;

        result
            .Invoking(x => x.GetValueOrDefault(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
        result2
            .Invoking(x => x.GetValueOrDefault(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(null, 0, 0)]
    [TestCase(null, 0, 1)]
    public void GetValueOrDefault(int? source, int expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .GetValueOrDefault(),
            _ => source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .GetValueOrDefault()
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(1, 2, 1, 0)]
    [TestCase(null, 1, 1, 0)]
    [TestCase(1, 2, 1, 1)]
    [TestCase(null, 1, 1, 1)]
    [TestCase(1, 2, 1, 2)]
    [TestCase(null, 1, 1, 2)]
    [TestCase(1, 2, 1, 3)]
    [TestCase(null, 1, 1, 3)]
    public void GetValueOrDefaultWithDefaultValue(int? source, int defaultValue, int expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .GetValueOrDefault(() => defaultValue),
            2 => source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .GetValueOrDefault(defaultValue),
            3 => source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .GetValueOrDefault(() => defaultValue),
            _ => source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .GetValueOrDefault(defaultValue)
        };

        currentResult.ShouldBe(expectedResult);
    }
}
