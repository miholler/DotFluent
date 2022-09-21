using NUnit.Framework;

namespace DotFluent
{
    [TestFixture]
    public sealed class StringIsNotLikeTest
    {
        #region Methods

        [Test]
        [TestCase("ABC", "ABC", false)]
        [TestCase("ABC", "abc", false)]
        [TestCase("ABC", "CBA", true)]
        [TestCase("", "", false)]
        [TestCase("ABC", "", true)]
        [TestCase("", "ABC", true)]
        [TestCase("", null, true)]
        [TestCase(null, "", true)]
        [TestCase(null, "ABC", true)]
        [TestCase("ABC", null, true)]
        [TestCase(null, null, false)]
        public void IsNotLike(string source, string value, bool expectedResult)
            => Assert.AreEqual(source.IsNotLike(value), expectedResult);

        #endregion
    }
}
