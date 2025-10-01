using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class ObjectIsNotNullTest
{
    [Test]
    [TestCase(1, true)]
    [TestCase("", true)]
    [TestCase(null, false)]
    public void IsNotNull(object source, bool expectedResult)
        => source
            .IsNotNull()
            .ShouldBe(expectedResult);
}
