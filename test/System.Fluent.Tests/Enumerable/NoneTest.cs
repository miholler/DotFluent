using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace System.Fluent.Tests.Enumerable
{
    [TestClass]
    public sealed class NoneTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.None());
        }

        [TestMethod]
        public void PredicateNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, bool> predicate = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.None(predicate));
        }

        [TestMethod]
        [DataRow(new int[0], true)]
        [DataRow(new[] { 1, 2, 3 }, false)]
        public void SourceNoPredicate(IEnumerable<int> source, bool expectedResult)
            => Assert.AreEqual(source.None(), expectedResult);

        [TestMethod]
        [DataRow(new int[0], true)]
        [DataRow(new[] { 1, 2, 3 }, false)]
        [DataRow(new[] { 1, 3, 5 }, true)]
        public void SourceWithPredicate(IEnumerable<int> source, bool expectedResult)
            => Assert.AreEqual(source.None(x => x % 2 == 0), expectedResult);

        #endregion
    }
}
