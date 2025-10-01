using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringIsNotNullNorEmptyTest
{
    [Test]
    [TestCase(null, false)]
    [TestCase("", false)]
    [TestCase(" ", true)]
    [TestCase("  ", true)]
    [TestCase("ABC", true)]
    [TestCase(" ABC ", true)]
    public void IsNotNullNorEmpty(string source, bool expectedResult)
        => source
            .IsNotNullNorEmpty()
            .ShouldBe(expectedResult);
}
