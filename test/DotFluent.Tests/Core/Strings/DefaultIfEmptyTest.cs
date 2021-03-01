using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class StringDefaultIfEmptyTest
    {
        #region Methods

        [TestMethod]
        public void DefaultFactoryNullThrowsException()
        {
            var source = string.Empty;
            Func<string> defaultFactory = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.DefaultIfEmpty(defaultFactory));
        }

        [TestMethod]
        [DataRow(null, "DEF", "DEF")]
        [DataRow("", "DEF", "DEF")]
        [DataRow("   ", "DEF", "DEF")]
        [DataRow("ABC", "DEF", "ABC")]
        public void DefaultIfEmpty(string source, string defaultValue, string expectedResult)
            => Assert.AreEqual(source.DefaultIfEmpty(defaultValue), expectedResult);

        [TestMethod]
        [DataRow(null, "DEF", "DEF")]
        [DataRow("", "DEF", "DEF")]
        [DataRow("   ", "DEF", "DEF")]
        [DataRow("ABC", "DEF", "ABC")]
        public void DefaultIfEmptyWithFactory(string source, string defaultValue, string expectedResult)
            => Assert.AreEqual(source.DefaultIfEmpty(() => defaultValue), expectedResult);

        #endregion
    }
}
