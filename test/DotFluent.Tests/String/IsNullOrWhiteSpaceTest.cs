using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.String
{
    [TestClass]
    public sealed class IsNullOrWhiteSpaceTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, true)]
        [DataRow(" ", true)]
        [DataRow("  ", true)]
        [DataRow("", true)]
        [DataRow("ABC", false)]
        [DataRow(" ABC ", false)]
        public void IsNullOrWhiteSpace(string source, bool expectedResult)
            => Assert.AreEqual(source.IsNullOrWhiteSpace(), expectedResult);

        #endregion
    }
}
