using NUnit.Framework;
using System;

namespace DotFluent
{
    [TestFixture]
    public sealed class StringIsNotEqualToTest
    {
        #region Methods

        [Test]
        [TestCase("ABC", "ABC", false)]
        [TestCase("ABC", "abc", true)]
        [TestCase("ABC", "CBA", true)]
        [TestCase("", "", false)]
        [TestCase("ABC", "", true)]
        [TestCase("", "ABC", true)]
        [TestCase("", null, true)]
        [TestCase(null, "", true)]
        [TestCase(null, "ABC", true)]
        [TestCase("ABC", null, true)]
        [TestCase(null, null, false)]
        public void IsNotEqualTo(string source, string value, bool expectedResult)
            => Assert.AreEqual(source.IsNotEqualTo(value), expectedResult);

        /*
        Compare three versions of the letter 'I' 
        LATIN SMALL LETTER I (U+0069)
        LATIN SMALL LETTER DOTLESS I (U+0131)
        LATIN CAPITAL LETTER I (U+0049) 
        */
        [Test]
        [TestCase("\u0069", "\u0131", StringComparison.InvariantCulture, true)]
        [TestCase("\u0069", "\u0049", StringComparison.InvariantCulture, true)]
        [TestCase("\u0131", "\u0049", StringComparison.InvariantCulture, true)]
        [TestCase("\u0069", "\u0069", StringComparison.InvariantCulture, false)]
        [TestCase("\u0049", "\u0049", StringComparison.InvariantCulture, false)]
        [TestCase("\u0131", "\u0131", StringComparison.InvariantCulture, false)]
        [TestCase("\u0069", "\u0131", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestCase("\u0069", "\u0049", StringComparison.InvariantCultureIgnoreCase, false)]
        [TestCase("\u0131", "\u0049", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestCase("\u0069", "\u0069", StringComparison.InvariantCultureIgnoreCase, false)]
        [TestCase("\u0049", "\u0049", StringComparison.InvariantCultureIgnoreCase, false)]
        [TestCase("\u0131", "\u0131", StringComparison.InvariantCultureIgnoreCase, false)]
        [TestCase("\u0069", "\u0131", StringComparison.Ordinal, true)]
        [TestCase("\u0069", "\u0049", StringComparison.Ordinal, true)]
        [TestCase("\u0131", "\u0049", StringComparison.Ordinal, true)]
        [TestCase("\u0069", "\u0069", StringComparison.Ordinal, false)]
        [TestCase("\u0049", "\u0049", StringComparison.Ordinal, false)]
        [TestCase("\u0131", "\u0131", StringComparison.Ordinal, false)]
        [TestCase("\u0069", "\u0131", StringComparison.OrdinalIgnoreCase, true)]
        [TestCase("\u0069", "\u0049", StringComparison.OrdinalIgnoreCase, false)]
        [TestCase("\u0131", "\u0049", StringComparison.OrdinalIgnoreCase, true)]
        [TestCase("\u0069", "\u0069", StringComparison.OrdinalIgnoreCase, false)]
        [TestCase("\u0049", "\u0049", StringComparison.OrdinalIgnoreCase, false)]
        [TestCase("\u0131", "\u0131", StringComparison.OrdinalIgnoreCase, false)]
        public void IsNotEqualToWithComparison(string source, string value, StringComparison comparison, bool expectedResult)
            => Assert.AreEqual(source.IsNotEqualTo(value, comparison), expectedResult);

        #endregion
    }
}
