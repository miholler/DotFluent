using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent
{
    [TestClass]
    public sealed class StringIsNullOrEmptyTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, true)]
        [DataRow("", true)]
        [DataRow(" ", false)]
        [DataRow("  ", false)]
        [DataRow("ABC", false)]
        [DataRow(" ABC ", false)]
        public void IsNullOrEmpty(string source, bool expectedResult)
            => Assert.AreEqual(source.IsNullOrEmpty(), expectedResult);

        #endregion
    }
}
