using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent
{
    [TestClass]
    public sealed class StringIsNotNullNorWhiteSpaceTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, false)]
        [DataRow(" ", false)]
        [DataRow("  ", false)]
        [DataRow("", false)]
        [DataRow("ABC", true)]
        [DataRow(" ABC ", true)]
        public void IsNotNullNorWhiteSpace(string source, bool expectedResult)
            => Assert.AreEqual(source.IsNotNullNorWhiteSpace(), expectedResult);

        #endregion
    }
}
