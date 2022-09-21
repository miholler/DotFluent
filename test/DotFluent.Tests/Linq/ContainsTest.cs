using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class ContainsTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.Contains(0, (x, y) => x == y));
        }

        [Test]
        public void ComparerNullThrowsException()
        {
            var source = new int[0];
            Func<int, int, bool> comparer = null;

            Assert.Throws<ArgumentNullException>(() => source.Contains(1, comparer));
        }

        [Test]
        [TestCase(new int[0], 0, false)]
        [TestCase(new int[] { 1, 2, 3 }, 4, false)]
        [TestCase(new int[] { 1, 2, 3 }, 2, true)]
        public void Contains(IEnumerable<int> source, int value, bool expectedResult)
            => Assert.AreEqual(source.Contains(value, (x, y) => x == y), expectedResult);

        #endregion
    }
}
