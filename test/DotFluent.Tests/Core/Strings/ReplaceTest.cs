using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringReplaceTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        string source = null;

        source
            .Invoking(x => x.Replace(Array.Empty<char>(), char.MinValue))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Replace(Array.Empty<string>(), string.Empty))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void OldCharsNullThrowsException()
    {
        var source = string.Empty;
        char[] oldChars = null;

        source
            .Invoking(x => x.Replace(oldChars, char.MinValue))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void OldValuesNullThrowsException()
    {
        var source = string.Empty;
        string[] oldValues = null;

        source
            .Invoking(x => x.Replace(oldValues, string.Empty))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase("ABC", new char[0], 'C', "ABC")]
    [TestCase("ABC", new[] { 'A' }, 'C', "CBC")]
    [TestCase("ABC", new[] { 'A', 'B' }, 'C', "CCC")]
    [TestCase("ABC", new[] { 'a', 'b' }, 'C', "ABC")]
    public void Replace(string source, char[] oldChars, char newChar, string expectedResult)
        => source
            .Replace(oldChars, newChar)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase("ABC", new string[0], "C", "ABC")]
    [TestCase("ABC", new[] { "A" }, null, "BC")]
    [TestCase("ABC", new[] { "A" }, "C", "CBC")]
    [TestCase("ABC", new[] { "A", "B" }, "C", "CCC")]
    [TestCase("ABC", new[] { "a", "b" }, "C", "ABC")]
    [TestCase("ABC", new[] { "AB", "C", }, "D", "DD")]
    public void ReplaceWithStrings(string source, string[] oldValues, string newValue, string expectedResult)
        => source
            .Replace(oldValues, newValue)
            .ShouldBe(expectedResult);
}
