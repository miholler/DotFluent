using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class LastOrDefaultTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.LastOrDefault(0));
            Assert.ThrowsException<ArgumentNullException>(() => source.LastOrDefault(() => 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.LastOrDefault(x => x == 0, 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.LastOrDefault(x => x == 0, () => 0));
        }

        [TestMethod]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int> defaultFactory = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.LastOrDefault(defaultFactory));
            Assert.ThrowsException<ArgumentNullException>(() => source.LastOrDefault(x => x == 0, defaultFactory));
        }

        [TestMethod]
        public void PredicateNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, bool> predicate = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.LastOrDefault(predicate, 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.LastOrDefault(predicate, () => 0));
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 2, 3 }, 3)]
        public void LastOrDefault(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.LastOrDefault(0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).LastOrDefault(0), expectedResult);
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 2, 3 }, 3)]
        public void LastOrDefaultWithFactory(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.LastOrDefault(() => 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).LastOrDefault(() => 0), expectedResult);
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 2, 3 }, 2)]
        public void LastOrDefaultWithPredicate(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.LastOrDefault(x => x == 2, 0), expectedResult);

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 2, 3 }, 2)]
        public void LastOrDefaultWithPredicateAndFactory(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.LastOrDefault(x => x == 2, () => 0), expectedResult);

        #endregion
    }
}
