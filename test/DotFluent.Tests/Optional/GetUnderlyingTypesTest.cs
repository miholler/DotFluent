using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class ResultGetUnderlyingTypesTest
{
    #region Methods

    [Test]
    public void ResultTypeNullThrowsException()
    {
        Type resultType = null;

        resultType
            .Invoking(Result.GetUnderlyingTypes)
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(typeof(int), new Type[0])]
    [TestCase(typeof(Nullable<>), new Type[0])]
    [TestCase(typeof(int?), new Type[0])]
    [TestCase(typeof(Result<>), new Type[0])]
    [TestCase(typeof(Result<int>), new Type[0])]
    [TestCase(typeof(Result<,>), new Type[0])]
    [TestCase(typeof(Result<string, int>), new[] { typeof(string), typeof(int) })]
    public void GetUnderlyingTypes(Type source, IEnumerable<Type> expectedResult)
        => Result
            .GetUnderlyingTypes(source)
            .ShouldBe(expectedResult);

    #endregion
}
