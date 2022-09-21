using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class ElementAtOrDefaultTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.ElementAtOrDefault(0, 0));
            Assert.Throws<ArgumentNullException>(() => source.ElementAtOrDefault(0, () => 0));
        }

        [Test]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int> defaultFactory = null;

            Assert.Throws<ArgumentNullException>(() => source.ElementAtOrDefault(0, defaultFactory));
        }

        [Test]
        [TestCase(new int[0], 0, 0)]
        [TestCase(new[] { 1, 2, 3 }, 3, 0)]
        [TestCase(new[] { 1, 2, 3 }, -3, 0)]
        [TestCase(new[] { 1, 2, 3 }, 1, 2)]
        public void ElementAtOrDefault(IEnumerable<int> source, int index, int expectedResult)
        {
            Assert.AreEqual(source.ElementAtOrDefault(index, 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).ElementAtOrDefault(index, 0), expectedResult);
        }

        [Test]
        [TestCase(new int[0], 0, 0)]
        [TestCase(new[] { 1, 2, 3 }, 3, 0)]
        [TestCase(new[] { 1, 2, 3 }, -3, 0)]
        [TestCase(new[] { 1, 2, 3 }, 1, 2)]
        public void ElementAtOrDefaultWithFactory(IEnumerable<int> source, int index, int expectedResult)
        {
            Assert.AreEqual(source.ElementAtOrDefault(index, () => 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).ElementAtOrDefault(index, () => 0), expectedResult);
        }

        #endregion
    }
}
