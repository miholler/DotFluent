using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class SingleOrDefaultTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.SingleOrDefault(0));
            Assert.ThrowsException<ArgumentNullException>(() => source.SingleOrDefault(() => 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.SingleOrDefault(x => x == 0, 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.SingleOrDefault(x => x == 0, () => 0));
        }

        [TestMethod]
        public void DefaultFactoryNullThrowsExceotion()
        {
            var source = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentNullException>(() => source.SingleOrDefault(null));
            Assert.ThrowsException<ArgumentNullException>(() => source.SingleOrDefault(x => x == 0, null));
        }

        [TestMethod]
        public void PredicateNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentNullException>(() => source.SingleOrDefault(null, 0));
            Assert.ThrowsException<ArgumentNullException>(() => source.SingleOrDefault(null, () => 0));
        }

        [TestMethod]
        public void MultipleElementsThrowsException()
        {
            var source = new[] { 1, 2, 3, 4 };
            var sourceSet = new HashSet<int>(source);

            Assert.ThrowsException<InvalidOperationException>(() => source.SingleOrDefault(0));
            Assert.ThrowsException<InvalidOperationException>(() => source.SingleOrDefault(() => 0));
            Assert.ThrowsException<InvalidOperationException>(() => source.SingleOrDefault(x => x % 2 == 0, 0));
            Assert.ThrowsException<InvalidOperationException>(() => source.SingleOrDefault(x => x % 2 == 0, () => 0));
            Assert.ThrowsException<InvalidOperationException>(() => sourceSet.SingleOrDefault(0));
            Assert.ThrowsException<InvalidOperationException>(() => sourceSet.SingleOrDefault(() => 0));
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1 }, 1)]
        public void SingleOrDefault(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.SingleOrDefault(0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).SingleOrDefault(0), expectedResult);
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1 }, 1)]
        public void SingleOrDefaultWithFactory(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.SingleOrDefault(() => 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).SingleOrDefault(() => 0), expectedResult);
        }

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 3, 5 }, 0)]
        [DataRow(new[] { 1, 2, 3 }, 2)]
        public void SingleOrDefaultWithPredicate(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.SingleOrDefault(x => x % 2 == 0, 0), expectedResult);

        [TestMethod]
        [DataRow(new int[0], 0)]
        [DataRow(new[] { 1, 3, 5 }, 0)]
        [DataRow(new[] { 1, 2, 3 }, 2)]
        public void SingleOrDefaultWithPredicateAndFactory(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.SingleOrDefault(x => x % 2 == 0, () => 0), expectedResult);

        #endregion
    }
}
