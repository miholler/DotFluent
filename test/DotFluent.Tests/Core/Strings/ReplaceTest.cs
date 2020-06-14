using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent.Tests.Strings
{
    [TestClass]
    public sealed class ReplaceTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            string source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Replace(Array.Empty<char>(), char.MinValue));
            Assert.ThrowsException<ArgumentNullException>(() => source.Replace(Array.Empty<string>(), string.Empty));
        }

        [TestMethod]
        public void OldCharsNullThrowsException()
        {
            var source = string.Empty;
            char[] oldChars = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Replace(oldChars, char.MinValue));
        }

        [TestMethod]
        public void OldValuesNullThrowsException()
        {
            var source = string.Empty;
            string[] oldValues = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Replace(oldValues, string.Empty));
        }

        [TestMethod]
        [DataRow("ABC", new char[0], 'C', "ABC")]
        [DataRow("ABC", new[] { 'A' }, 'C', "CBC")]
        [DataRow("ABC", new[] { 'A', 'B' }, 'C', "CCC")]
        [DataRow("ABC", new[] { 'a', 'b' }, 'C', "ABC")]
        public void Replace(string source, char[] oldChars, char newChar, string expectedResult)
            => Assert.AreEqual(source.Replace(oldChars, newChar), expectedResult);

        [TestMethod]
        [DataRow("ABC", new string[0], "C", "ABC")]
        [DataRow("ABC", new[] { "A" }, null, "BC")]
        [DataRow("ABC", new[] { "A" }, "C", "CBC")]
        [DataRow("ABC", new[] { "A", "B" }, "C", "CCC")]
        [DataRow("ABC", new[] { "a", "b" }, "C", "ABC")]
        [DataRow("ABC", new[] { "AB", "C", }, "D", "DD")]
        public void ReplaceWithStrings(string source, string[] oldValues, string newValue, string expectedResult)
            => Assert.AreEqual(source.Replace(oldValues, newValue), expectedResult);

        #endregion
    }
}
