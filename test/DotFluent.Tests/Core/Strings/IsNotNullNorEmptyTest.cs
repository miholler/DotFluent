using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.Strings
{
    [TestClass]
    public sealed class IsNotNullNorEmptyTest
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
