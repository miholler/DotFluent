using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class FirstOrDefaultTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.FirstOrDefault(0));
            Assert.ThrowsException<ArgumentNullException>(() => source.FirstOrDefault(() => 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.FirstOrDefault(x => x == 0, 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.FirstOrDefault(x => x == 0, () => 0));
        }

        [TestMethod]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentNullException>(() => source.FirstOrDefault(null));
            Assert.ThrowsException<ArgumentNullException>(() => source.FirstOrDefault(x => x == 0, null));
        }

        [TestMethod]
        public void PredicateNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentNullException>(() => source.FirstOrDefault(null, 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.FirstOrDefault(null, () => 0));
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 2, 3 }, 1)]
        public void FirstOrDefault(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.FirstOrDefault(0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).FirstOrDefault(0), expectedResult);
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 2, 3 }, 1)]
        public void FirstOrDefaultWithFactory(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.FirstOrDefault(() => 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).FirstOrDefault(() => 0), expectedResult);
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 2, 3 }, 2)]
        public void FirstOrDefaultWithPredicate(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.FirstOrDefault(x => x == 2, 0), expectedResult);

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 2, 3 }, 2)]
        public void FirstOrDefaultWithPredicateAndFactory(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.FirstOrDefault(x => x == 2, () => 0), expectedResult);

        #endregion
    }
}
