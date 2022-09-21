using NUnit.Framework;

namespace DotFluent
{
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
            => Assert.AreEqual(source.IsNotNullNorWhiteSpace(), expectedResult);

        #endregion
    }
}
