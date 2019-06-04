using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.String
{
    [TestClass]
    public sealed class IsNotBinaryEqualToTest
    {
        #region Methods

        /*
        Compare three versions of the letter 'I' 
        LATIN SMALL LETTER I (U+0069)
        LATIN SMALL LETTER DOTLESS I (U+0131)
        LATIN CAPITAL LETTER I (U+0049) 
        */
        [TestMethod]
        [DataRow("\u0069", "\u0131", false, true)]
        [DataRow("\u0069", "\u0049", false, true)]
        [DataRow("\u0131", "\u0049", false, true)]
        [DataRow("\u0069", "\u0069", false, false)]
        [DataRow("\u0049", "\u0049", false, false)]
        [DataRow("\u0131", "\u0131", false, false)]
        [DataRow("\u0069", "\u0131", true, true)]
        [DataRow("\u0069", "\u0049", true, false)]
        [DataRow("\u0131", "\u0049", true, true)]
        [DataRow("\u0069", "\u0069", true, false)]
        [DataRow("\u0049", "\u0049", true, false)]
        [DataRow("\u0131", "\u0131", true, false)]
        public void IsNotBinaryEqualTo(string source, string value, bool ignoreCase, bool expectedResult)
            => Assert.AreEqual(source.IsNotBinaryEqualTo(value, ignoreCase), expectedResult);

        #endregion
    }
}
