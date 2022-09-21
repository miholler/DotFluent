using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class LastOrDefaultTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(0));
            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(() => 0));
            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(x => x == 0, 0));
            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(x => x == 0, () => 0));
        }

        [Test]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int> defaultFactory = null;

            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(defaultFactory));
            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(x => x == 0, defaultFactory));
        }

        [Test]
        public void PredicateNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, bool> predicate = null;

            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(predicate, 0));
            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(predicate, () => 0));
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 3)]
        public void LastOrDefault(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.LastOrDefault(0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).LastOrDefault(0), expectedResult);
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 3)]
        public void LastOrDefaultWithFactory(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.LastOrDefault(() => 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).LastOrDefault(() => 0), expectedResult);
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 2)]
        public void LastOrDefaultWithPredicate(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.LastOrDefault(x => x == 2, 0), expectedResult);

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 2)]
        public void LastOrDefaultWithPredicateAndFactory(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.LastOrDefault(x => x == 2, () => 0), expectedResult);

        #endregion
    }
}
