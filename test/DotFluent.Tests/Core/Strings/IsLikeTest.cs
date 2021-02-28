using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent
{
    [TestClass]
    public sealed class StringIsLikeTest
    {
        #region Methods

        [TestMethod]
        [DataRow("ABC", "ABC", true)]
        [DataRow("ABC", "abc", true)]
        [DataRow("ABC", "CBA", false)]
        [DataRow("", "", true)]
        [DataRow("ABC", "", false)]
        [DataRow("", "ABC", false)]
        [DataRow("", null, false)]
        [DataRow(null, "", false)]
        [DataRow(null, "ABC", false)]
        [DataRow("ABC", null, false)]
        [DataRow(null, null, true)]
        public void IsLike(string source, string value, bool expectedResult)
            => Assert.AreEqual(source.IsLike(value), expectedResult);

        #endregion
    }
}
