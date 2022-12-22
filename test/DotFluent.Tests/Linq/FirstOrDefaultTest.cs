using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class FirstOrDefaultTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(0));
            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(() => 0));
            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(x => x == 0, 0));
            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(x => x == 0, () => 0));
        }

        [Test]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int> defaultFactory = null;

            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(defaultFactory));
            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(x => x == 0, defaultFactory));
        }

        [Test]
        public void PredicateNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, bool> predicate = null;

            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(predicate, 0));
            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(predicate, () => 0));
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 1)]
        public void FirstOrDefault(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.FirstOrDefault(0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).FirstOrDefault(0), expectedResult);
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 1)]
        public void FirstOrDefaultWithFactory(IEnumerable<int> source, int expectedResult)
        {
            Assert.AreEqual(source.FirstOrDefault(() => 0), expectedResult);
            Assert.AreEqual(new HashSet<int>(source).FirstOrDefault(() => 0), expectedResult);
        }

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 2)]
        public void FirstOrDefaultWithPredicate(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.FirstOrDefault(x => x == 2, 0), expectedResult);

        [Test]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 2)]
        public void FirstOrDefaultWithPredicateAndFactory(IEnumerable<int> source, int expectedResult)
            => Assert.AreEqual(source.FirstOrDefault(x => x == 2, () => 0), expectedResult);

        #endregion
    }
}
