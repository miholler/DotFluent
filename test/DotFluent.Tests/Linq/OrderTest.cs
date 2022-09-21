using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class OrderTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.Order());
            Assert.Throws<ArgumentNullException>(() => source.Order((x, y) => 0));
            Assert.Throws<ArgumentNullException>(() => source.Order(Comparer<int>.Default));
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            Comparison<int> comparison = null;

            Assert.Throws<ArgumentNullException>(() => Array.Empty<int>().Order(comparison));
        }

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
        public void Order(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.Order().SequenceEqual(expectedResult));

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
        public void OrderWithComparison(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.Order((x, y) => x > y ? 1 : x == y ? 0 : -1).SequenceEqual(expectedResult));

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
        public void OrderWithComparer(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.Order(Comparer<int>.Default).SequenceEqual(expectedResult));

        #endregion
    }
}
