using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.Strings
{
    [TestClass]
    public sealed class IsNotLikeTest
    {
        #region Methods

        [TestMethod]
        [DataRow("ABC", "ABC", false)]
        [DataRow("ABC", "abc", false)]
        [DataRow("ABC", "CBA", true)]
        [DataRow("", "", false)]
        [DataRow("ABC", "", true)]
        [DataRow("", "ABC", true)]
        [DataRow("", null, true)]
        [DataRow(null, "", true)]
        [DataRow(null, "ABC", true)]
        [DataRow("ABC", null, true)]
        [DataRow(null, null, false)]
        public void IsNotLike(string source, string value, bool expectedResult)
            => Assert.AreEqual(source.IsNotLike(value), expectedResult);

        #endregion
    }
}
