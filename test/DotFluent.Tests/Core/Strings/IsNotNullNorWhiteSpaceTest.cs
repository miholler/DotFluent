using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringIsNotNullNorWhiteSpaceTest
{
    #region Methods

    [Test]
    [TestCase(null, false)]
    [TestCase(" ", false)]
    [TestCase("  ", false)]
    [TestCase("", false)]
    [TestCase("ABC", true)]
    [TestCase(" ABC ", true)]
    public void IsNotNullNorWhiteSpace(string source, bool expectedResult)
        => source
            .IsNotNullNorWhiteSpace()
            .ShouldBe(expectedResult);

    #endregion
}
