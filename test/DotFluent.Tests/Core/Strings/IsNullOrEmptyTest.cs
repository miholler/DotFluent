using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringIsNullOrEmptyTest
{
    #region Methods

    [Test]
    [TestCase(null, true)]
    [TestCase("", true)]
    [TestCase(" ", false)]
    [TestCase("  ", false)]
    [TestCase("ABC", false)]
    [TestCase(" ABC ", false)]
    public void IsNullOrEmpty(string source, bool expectedResult)
        => source
            .IsNullOrEmpty()
            .ShouldBe(expectedResult);

    #endregion
}
