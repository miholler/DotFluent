using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.Strings
{
    [TestClass]
    public sealed class IsNotNullNorWhiteSpaceTest
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
