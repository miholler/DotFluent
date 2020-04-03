using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.Strings
{
    [TestClass]
    public sealed class IsNullOrEmptyTest
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
