using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OptionGetUnderlyingTypeTest
{
    #region Methods

    [Test]
    public void OptionTypeNullThrowsException()
    {
        Type optionType = null;

        optionType
            .Invoking(Option.GetUnderlyingType)
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(typeof(int), null)]
    [TestCase(typeof(Nullable<>), null)]
    [TestCase(typeof(int?), null)]
    [TestCase(typeof(Option<>), null)]
    [TestCase(typeof(Option<int>), typeof(int))]
    public void GetUnderlyingType(Type source, Type expectedResult)
        => Option
            .GetUnderlyingType(source)
            .ShouldBe(expectedResult);

    #endregion
}

[TestFixture]
public sealed class ResultGetUnderlyingTypeTest
{
    #region Methods

    [Test]
    public void ResultTypeNullThrowsException()
    {
        Type resultType = null;

        resultType
            .Invoking(Result.GetUnderlyingType)
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(typeof(int), null)]
    [TestCase(typeof(Nullable<>), null)]
    [TestCase(typeof(int?), null)]
    [TestCase(typeof(Result<>), null)]
    [TestCase(typeof(Result<int>), typeof(int))]
    public void GetUnderlyingType(Type source, Type expectedResult)
        => Result
            .GetUnderlyingType(source)
            .ShouldBe(expectedResult);

    #endregion
}
