using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class NoneTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.None());
        }

        [Test]
        public void PredicateNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, bool> predicate = null;

            Assert.Throws<ArgumentNullException>(() => source.None(predicate));
        }

        [Test]
        [TestCase(new int[0], true)]
        [TestCase(new[] { 1, 2, 3 }, false)]
        public void SourceNoPredicate(IEnumerable<int> source, bool expectedResult)
            => Assert.AreEqual(source.None(), expectedResult);

        [Test]
        [TestCase(new int[0], true)]
        [TestCase(new[] { 1, 2, 3 }, false)]
        [TestCase(new[] { 1, 3, 5 }, true)]
        public void SourceWithPredicate(IEnumerable<int> source, bool expectedResult)
            => Assert.AreEqual(source.None(x => x % 2 == 0), expectedResult);

        #endregion
    }
}
