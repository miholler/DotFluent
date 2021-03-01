using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent
{
    [TestClass]
    public sealed class StringIsNotNullNorEmptyTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow(" ", true)]
        [DataRow("  ", true)]
        [DataRow("ABC", true)]
        [DataRow(" ABC ", true)]
        public void IsNotNullNorEmpty(string source, bool expectedResult)
            => Assert.AreEqual(source.IsNotNullNorEmpty(), expectedResult);

        #endregion
    }
}
