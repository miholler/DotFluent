using NUnit.Framework;

namespace DotFluent
{
    [TestFixture]
    public sealed class StringIsNullOrWhiteSpaceTest
    {
        #region Methods

        [Test]
        [TestCase(null, true)]
        [TestCase(" ", true)]
        [TestCase("  ", true)]
        [TestCase("", true)]
        [TestCase("ABC", false)]
        [TestCase(" ABC ", false)]
        public void IsNullOrWhiteSpace(string source, bool expectedResult)
            => Assert.AreEqual(source.IsNullOrWhiteSpace(), expectedResult);

        #endregion
    }
}
