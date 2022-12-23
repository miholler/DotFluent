using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class OrderByTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.OrderBy(x => x, (x, y) => 0));
        }

        [Test]
        public void KeySelectorNullThrowsException()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            source
                .Invoking(x => x.OrderBy(keySelector, (x, y) => 0))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ComparisonNullThrowsException()
        {
            Comparison<int> comparison = null;

            Assert.Throws<ArgumentNullException>(() => Array.Empty<int>().OrderBy(x => x, comparison));
        }

        [Test]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 3, 1, 2 }, new[] { 1, 2, 3 })]
        public void OrderBy(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.OrderBy(x => x, Comparer<int>.Default.Compare).SequenceEqual(expectedResult));

        #endregion
    }
}
