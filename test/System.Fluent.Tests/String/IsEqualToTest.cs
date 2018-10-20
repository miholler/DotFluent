using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Fluent.Tests.String
{
    [TestClass]
    public sealed class IsEqualToTest
    {
        #region Methods

        /*
        Compare three versions of the letter 'I' 
        LATIN SMALL LETTER I (U+0069)
        LATIN SMALL LETTER DOTLESS I (U+0131)
        LATIN CAPITAL LETTER I (U+0049) 
        */
        [TestMethod]
        [DataRow("\u0069", "\u0131", StringComparison.InvariantCulture, false)]
        [DataRow("\u0069", "\u0049", StringComparison.InvariantCulture, false)]
        [DataRow("\u0131", "\u0049", StringComparison.InvariantCulture, false)]
        [DataRow("\u0069", "\u0069", StringComparison.InvariantCulture, true)]
        [DataRow("\u0049", "\u0049", StringComparison.InvariantCulture, true)]
        [DataRow("\u0131", "\u0131", StringComparison.InvariantCulture, true)]
        [DataRow("\u0069", "\u0131", StringComparison.InvariantCultureIgnoreCase, false)]
        [DataRow("\u0069", "\u0049", StringComparison.InvariantCultureIgnoreCase, true)]
        [DataRow("\u0131", "\u0049", StringComparison.InvariantCultureIgnoreCase, false)]
        [DataRow("\u0069", "\u0069", StringComparison.InvariantCultureIgnoreCase, true)]
        [DataRow("\u0049", "\u0049", StringComparison.InvariantCultureIgnoreCase, true)]
        [DataRow("\u0131", "\u0131", StringComparison.InvariantCultureIgnoreCase, true)]
        [DataRow("\u0069", "\u0131", StringComparison.Ordinal, false)]
        [DataRow("\u0069", "\u0049", StringComparison.Ordinal, false)]
        [DataRow("\u0131", "\u0049", StringComparison.Ordinal, false)]
        [DataRow("\u0069", "\u0069", StringComparison.Ordinal, true)]
        [DataRow("\u0049", "\u0049", StringComparison.Ordinal, true)]
        [DataRow("\u0131", "\u0131", StringComparison.Ordinal, true)]
        [DataRow("\u0069", "\u0131", StringComparison.OrdinalIgnoreCase, false)]
        [DataRow("\u0069", "\u0049", StringComparison.OrdinalIgnoreCase, true)]
        [DataRow("\u0131", "\u0049", StringComparison.OrdinalIgnoreCase, false)]
        [DataRow("\u0069", "\u0069", StringComparison.OrdinalIgnoreCase, true)]
        [DataRow("\u0049", "\u0049", StringComparison.OrdinalIgnoreCase, true)]
        [DataRow("\u0131", "\u0131", StringComparison.OrdinalIgnoreCase, true)]
        public void IsEqualTo(string source, string value, StringComparison comparison, bool expectedResult)
            => Assert.AreEqual(source.IsEqualTo(value, comparison), expectedResult);

        #endregion
    }
}
