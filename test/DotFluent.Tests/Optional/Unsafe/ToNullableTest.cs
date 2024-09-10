using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Unsafe;

[TestFixture]
public sealed class OptionToNullableTest
{
    #region Methods

    [Test]
    [TestCase(null)]
    [TestCase(1)]
    public void ToNullable(int? source)
        => source
            .ToOption()
            .ToNullable()
            .ShouldBe(source);

    #endregion
}

[TestFixture]
public sealed class ResultToNullableTest
{
    #region Methods

    [Test]
    [TestCase(1, 0)]
    [TestCase(1, 1)]
    [TestCase(null, 0)]
    [TestCase(null, 1)]
    public void ToNullable(int? source, int overload)
    {
        var currentResult = overload switch
        {
            1 => source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .ToNullable(),
            _ => source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .ToNullable()
        };

        currentResult.ShouldBe(source);
    }

    #endregion
}
