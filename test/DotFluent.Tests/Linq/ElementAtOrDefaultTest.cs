using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class ElementAtOrDefaultTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.ElementAtOrDefault(0, 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.ElementAtOrDefault(0, () => 0));
        }

        [TestMethod]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int> defaultFactory = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.ElementAtOrDefault(0, defaultFactory));
        }

        [TestMethod]
        [DataRow(new int[0], 0, 0)]
        [DataRow(new[] { 1, 2, 3 }, 3, 0)]
        [DataRow(new[] { 1, 2, 3 }, -3, 0)]
        [DataRow(new[] { 1, 2, 3 }, 1, 2)]
        public void ElementAtOrDefault(IEnumerable<int> source, int index, int expectedResult)
        {
            Assert.AreEqual(source.ElementAtOrDefault(index, 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).ElementAtOrDefault(index, 0), expectedResult);
        }

        [TestMethod]
        [DataRow(new int[0], 0, 0)]
        [DataRow(new[] { 1, 2, 3 }, 3, 0)]
        [DataRow(new[] { 1, 2, 3 }, -3, 0)]
        [DataRow(new[] { 1, 2, 3 }, 1, 2)]
        public void ElementAtOrDefaultWithFactory(IEnumerable<int> source, int index, int expectedResult)
        {
            Assert.AreEqual(source.ElementAtOrDefault(index, () => 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).ElementAtOrDefault(index, () => 0), expectedResult);
        }

        #endregion
    }
}
