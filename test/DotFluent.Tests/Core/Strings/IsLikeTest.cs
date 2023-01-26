using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringIsLikeTest
{
    #region Methods

    [Test]
    [TestCase("ABC", "ABC", true)]
    [TestCase("ABC", "abc", true)]
    [TestCase("ABC", "CBA", false)]
    [TestCase("", "", true)]
    [TestCase("ABC", "", false)]
    [TestCase("", "ABC", false)]
    [TestCase("", null, false)]
    [TestCase(null, "", false)]
    [TestCase(null, "ABC", false)]
    [TestCase("ABC", null, false)]
    [TestCase(null, null, true)]
    public void IsLike(string source, string value, bool expectedResult)
        => source
            .IsLike(value)
            .ShouldBe(expectedResult);

    #endregion
}
