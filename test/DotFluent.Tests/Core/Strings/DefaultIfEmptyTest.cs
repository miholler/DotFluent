using NUnit.Framework;
using System;

namespace DotFluent
{
    [TestFixture]
    public sealed class StringDefaultIfEmptyTest
    {
        #region Methods

        [Test]
        public void DefaultFactoryNullThrowsException()
        {
            var source = string.Empty;
            Func<string> defaultFactory = null;

            Assert.Throws<ArgumentNullException>(() => source.DefaultIfEmpty(defaultFactory));
        }

        [Test]
        [TestCase(null, "DEF", "DEF")]
        [TestCase("", "DEF", "DEF")]
        [TestCase("   ", "DEF", "DEF")]
        [TestCase("ABC", "DEF", "ABC")]
        public void DefaultIfEmpty(string source, string defaultValue, string expectedResult)
            => Assert.AreEqual(source.DefaultIfEmpty(defaultValue), expectedResult);

        [Test]
        [TestCase(null, "DEF", "DEF")]
        [TestCase("", "DEF", "DEF")]
        [TestCase("   ", "DEF", "DEF")]
        [TestCase("ABC", "DEF", "ABC")]
        public void DefaultIfEmptyWithFactory(string source, string defaultValue, string expectedResult)
            => Assert.AreEqual(source.DefaultIfEmpty(() => defaultValue), expectedResult);

        #endregion
    }
}
