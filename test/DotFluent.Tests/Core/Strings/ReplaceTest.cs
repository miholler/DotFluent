using NUnit.Framework;
using System;

namespace DotFluent
{
    [TestFixture]
    public sealed class StringReplaceTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            string source = null;

            Assert.Throws<ArgumentNullException>(() => source.Replace(Array.Empty<char>(), char.MinValue));
            Assert.Throws<ArgumentNullException>(() => source.Replace(Array.Empty<string>(), string.Empty));
        }

        [Test]
        public void OldCharsNullThrowsException()
        {
            var source = string.Empty;
            char[] oldChars = null;

            Assert.Throws<ArgumentNullException>(() => source.Replace(oldChars, char.MinValue));
        }

        [Test]
        public void OldValuesNullThrowsException()
        {
            var source = string.Empty;
            string[] oldValues = null;

            Assert.Throws<ArgumentNullException>(() => source.Replace(oldValues, string.Empty));
        }

        [Test]
        [TestCase("ABC", new char[0], 'C', "ABC")]
        [TestCase("ABC", new[] { 'A' }, 'C', "CBC")]
        [TestCase("ABC", new[] { 'A', 'B' }, 'C', "CCC")]
        [TestCase("ABC", new[] { 'a', 'b' }, 'C', "ABC")]
        public void Replace(string source, char[] oldChars, char newChar, string expectedResult)
            => Assert.AreEqual(source.Replace(oldChars, newChar), expectedResult);

        [Test]
        [TestCase("ABC", new string[0], "C", "ABC")]
        [TestCase("ABC", new[] { "A" }, null, "BC")]
        [TestCase("ABC", new[] { "A" }, "C", "CBC")]
        [TestCase("ABC", new[] { "A", "B" }, "C", "CCC")]
        [TestCase("ABC", new[] { "a", "b" }, "C", "ABC")]
        [TestCase("ABC", new[] { "AB", "C", }, "D", "DD")]
        public void ReplaceWithStrings(string source, string[] oldValues, string newValue, string expectedResult)
            => Assert.AreEqual(source.Replace(oldValues, newValue), expectedResult);

        #endregion
    }
}
