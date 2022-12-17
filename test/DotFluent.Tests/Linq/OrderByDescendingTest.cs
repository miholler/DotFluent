using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class OrderByDescendingTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.OrderByDescending(x => x, (x, y) => 0));
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            Comparison<int> comparison = null;

            Assert.Throws<ArgumentNullException>(() => Array.Empty<int>().OrderByDescending(x => x, comparison));
        }

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 1, 3, 2 }, new[] { 3, 2, 1 })]
        public void OrderByDescending(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderByDescending(x => x, Comparer<int>.Default.Compare).SequenceEqual(expectedResult));

        #endregion
    }
}
