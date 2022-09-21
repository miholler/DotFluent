using NUnit.Framework;

namespace DotFluent
{
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
            => Assert.AreEqual(source.IsNullOrEmpty(), expectedResult);

        #endregion
    }
}
