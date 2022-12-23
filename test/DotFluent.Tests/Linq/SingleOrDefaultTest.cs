using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class SingleOrDefaultTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(0));
            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(() => 0));
            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(x => x == 0, 0));
            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(x => x == 0, () => 0));
        }

        [Test]
        public void DefaultFactoryNullThrowsExceotion()
        {
            var source = new[] { 1, 2, 3 };
            Func<int> defaultFactory = null;

            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(defaultFactory));
            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(x => x == 0, defaultFactory));
        }

        [Test]
        public void PredicateNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, bool> predicate = null;

            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(predicate, 0));
            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(predicate, () => 0));
        }

        [Test]
        public void MultipleElementsThrowsException()
        {
            var source = new[] { 1, 2, 3, 4 };
            var sourceSet = new HashSet<int>(source);

            Assert.Throws<InvalidOperationException>(() => source.SingleOrDefault(0));
            Assert.Throws<InvalidOperationException>(() => source.SingleOrDefault(() => 0));
            Assert.Throws<InvalidOperationException>(() => source.SingleOrDefault(x => x % 2 == 0, 0));
            Assert.Throws<InvalidOperationException>(() => source.SingleOrDefault(x => x % 2 == 0, () => 0));
            Assert.Throws<InvalidOperationException>(() => sourceSet.SingleOrDefault(0));
            Assert.Throws<InvalidOperationException>(() => sourceSet.SingleOrDefault(() => 0));
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1 }, 1)]
        public void SingleOrDefault(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.SingleOrDefault(0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).SingleOrDefault(0), expectedResult);
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1 }, 1)]
        public void SingleOrDefaultWithFactory(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.SingleOrDefault(() => 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).SingleOrDefault(() => 0), expectedResult);
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 3, 5 }, 0)]
        [TestCase(new[] { 1, 2, 3 }, 2)]
        public void SingleOrDefaultWithPredicate(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.SingleOrDefault(x => x % 2 == 0, 0), expectedResult);

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 3, 5 }, 0)]
        [TestCase(new[] { 1, 2, 3 }, 2)]
        public void SingleOrDefaultWithPredicateAndFactory(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.SingleOrDefault(x => x % 2 == 0, () => 0), expectedResult);

        #endregion
    }
}
