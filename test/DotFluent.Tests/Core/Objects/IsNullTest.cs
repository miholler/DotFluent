using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class ObjectIsNullTest
{
    [Test]
    [TestCase(1, false)]
    [TestCase("", false)]
    [TestCase(null, true)]
    public void IsNull(object source, bool expectedResult)
        => source
            .IsNull()
            .ShouldBe(expectedResult);
}
