using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class ForEachTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.ForEach(x => x++));
            Assert.Throws<ArgumentNullException>(() => source.ForEach((x, i) => x += i));
        }

        [Test]
        public void ActionNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Action<int> action = null;
            Action<int, int> indexAction = null;

            Assert.Throws<ArgumentNullException>(() => source.ForEach(action));
            Assert.Throws<ArgumentNullException>(() => source.ForEach(indexAction));
        }

        [Test]
        public void Iteration()
        {
            var result = 0;
            new[] { 1, 2, 3, 4 }.ForEach(x => result += x);

            Assert.AreEqual(result, 10);
        }

        [Test]
        public void IterationWithIndex()
        {
            var result = 0;
            new[] { 1, 2, 3, 4 }.ForEach((x, i) => result += x + i);

            Assert.AreEqual(result, 16);
        }

        #endregion
    }
}
