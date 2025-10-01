using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringIsEqualToTest
{
    [Test]
    [TestCase("ABC", "ABC", true)]
    [TestCase("ABC", "abc", false)]
    [TestCase("ABC", "CBA", false)]
    [TestCase("", "", true)]
    [TestCase("ABC", "", false)]
    [TestCase("", "ABC", false)]
    [TestCase("", null, false)]
    [TestCase(null, "", false)]
    [TestCase(null, "ABC", false)]
    [TestCase("ABC", null, false)]
    [TestCase(null, null, true)]
    public void IsEqualTo(string source, string value, bool expectedResult)
        => source
            .IsEqualTo(value)
            .ShouldBe(expectedResult);

    /*
    Compare three versions of the letter 'I' 
    LATIN SMALL LETTER I (U+0069)
    LATIN SMALL LETTER DOTLESS I (U+0131)
    LATIN CAPITAL LETTER I (U+0049) 
    */
    [Test]
    [TestCase("\u0069", "\u0131", StringComparison.InvariantCulture, false)]
    [TestCase("\u0069", "\u0049", StringComparison.InvariantCulture, false)]
    [TestCase("\u0131", "\u0049", StringComparison.InvariantCulture, false)]
    [TestCase("\u0069", "\u0069", StringComparison.InvariantCulture, true)]
    [TestCase("\u0049", "\u0049", StringComparison.InvariantCulture, true)]
    [TestCase("\u0131", "\u0131", StringComparison.InvariantCulture, true)]
    [TestCase("\u0069", "\u0131", StringComparison.InvariantCultureIgnoreCase, false)]
    [TestCase("\u0069", "\u0049", StringComparison.InvariantCultureIgnoreCase, true)]
    [TestCase("\u0131", "\u0049", StringComparison.InvariantCultureIgnoreCase, false)]
    [TestCase("\u0069", "\u0069", StringComparison.InvariantCultureIgnoreCase, true)]
    [TestCase("\u0049", "\u0049", StringComparison.InvariantCultureIgnoreCase, true)]
    [TestCase("\u0131", "\u0131", StringComparison.InvariantCultureIgnoreCase, true)]
    [TestCase("\u0069", "\u0131", StringComparison.Ordinal, false)]
    [TestCase("\u0069", "\u0049", StringComparison.Ordinal, false)]
    [TestCase("\u0131", "\u0049", StringComparison.Ordinal, false)]
    [TestCase("\u0069", "\u0069", StringComparison.Ordinal, true)]
    [TestCase("\u0049", "\u0049", StringComparison.Ordinal, true)]
    [TestCase("\u0131", "\u0131", StringComparison.Ordinal, true)]
    [TestCase("\u0069", "\u0131", StringComparison.OrdinalIgnoreCase, false)]
    [TestCase("\u0069", "\u0049", StringComparison.OrdinalIgnoreCase, true)]
    [TestCase("\u0131", "\u0049", StringComparison.OrdinalIgnoreCase, false)]
    [TestCase("\u0069", "\u0069", StringComparison.OrdinalIgnoreCase, true)]
    [TestCase("\u0049", "\u0049", StringComparison.OrdinalIgnoreCase, true)]
    [TestCase("\u0131", "\u0131", StringComparison.OrdinalIgnoreCase, true)]
    public void IsEqualToWithComparison(string source, string value, StringComparison comparison, bool expectedResult)
        => source
            .IsEqualTo(value, comparison)
            .ShouldBe(expectedResult);
}
