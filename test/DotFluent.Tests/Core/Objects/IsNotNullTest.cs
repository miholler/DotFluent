using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class ObjectIsNotNullTest
{
    #region Methods

    [Test]
    [TestCase(1, true)]
    [TestCase("", true)]
    [TestCase(null, false)]
    public void IsNotNull(object source, bool expectedResult)
        => source
            .IsNotNull()
            .ShouldBe(expectedResult);

    #endregion
}
