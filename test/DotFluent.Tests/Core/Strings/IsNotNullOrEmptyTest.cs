using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.Strings
{
    [TestClass]
    public sealed class IsNotNullOrEmptyTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow(" ", true)]
        [DataRow("  ", true)]
        [DataRow("ABC", true)]
        [DataRow(" ABC ", true)]
        public void IsNotNullOrEmpty(string source, bool expectedResult)
            => Assert.AreEqual(source.IsNotNullOrEmpty(), expectedResult);

        #endregion
    }
}
