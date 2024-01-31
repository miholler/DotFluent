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
    [TestCase(1)]
    [TestCase(null)]
    public void ToNullable(int? source)
        => source
            .Match(Result.Ok, () => Result.Error<int>(new()))
            .ToNullable()
            .ShouldBe(source);

    #endregion
}
