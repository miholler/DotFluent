using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class DefaultIfEmptyTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.DefaultIfEmpty(() => 0).ToArray());
        }

        [Test]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int> defaultFactory = null;

            Assert.Throws<ArgumentNullException>(() => source.DefaultIfEmpty(defaultFactory).ToArray());
        }

        [Test]
        [TestCase(new int[0], new[] { 0 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        public void DefaultIfEmpty(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.DefaultIfEmpty(() => 0).SequenceEqual(expectedResult));

        #endregion
    }
}
