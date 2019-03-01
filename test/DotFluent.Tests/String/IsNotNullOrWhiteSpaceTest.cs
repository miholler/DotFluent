using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.String
{
    [TestClass]
    public sealed class IsNotNullOrWhiteSpaceTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, false)]
        [DataRow(" ", false)]
        [DataRow("  ", false)]
        [DataRow("", false)]
        [DataRow("ABC", true)]
        [DataRow(" ABC ", true)]
        public void IsNotNullOrWhiteSpace(string source, bool expectedResult)
            => Assert.AreEqual(source.IsNotNullOrWhiteSpace(), expectedResult);

        #endregion
    }
}
