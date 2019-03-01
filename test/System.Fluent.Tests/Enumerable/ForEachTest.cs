using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace System.Fluent.Tests.Enumerable
{
    [TestClass]
    public sealed class ForEachTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.ForEach(x => x++));
            Assert.ThrowsException<ArgumentNullException>(() => source.ForEach((x, i) => x += i));
        }

        [TestMethod]
        public void ActionNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Action<int> action = null;
            Action<int, int> indexAction = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.ForEach(action));
            Assert.ThrowsException<ArgumentNullException>(() => source.ForEach(indexAction));
        }

        [TestMethod]
        public void Iteration()
        {
            var result = 0;
            new[] { 1, 2, 3, 4 }.ForEach(x => result += x);

            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void IterationWithIndex()
        {
            var result = 0;
            new[] { 1, 2, 3, 4 }.ForEach((x, i) => result += x + i);

            Assert.AreEqual(result, 16);
        }

        #endregion
    }
}
