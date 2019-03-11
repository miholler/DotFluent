using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class DistinctTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.Distinct((x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.Distinct((x, y) => x == y, x => x.GetHashCode()));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            var source = new int[0];

            Assert.ThrowsException<ArgumentNullException>(() => source.Distinct(null));
            Assert.ThrowsException<ArgumentNullException>(() => source.Distinct(null, x => x.GetHashCode()));
        }

        [TestMethod]
        public void HashCodeProviderNullThrowsException()
        {
            var source = new int[0];

            Assert.ThrowsException<ArgumentNullException>(() => source.Distinct((x, y) => x == y, null));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 })]
        public void Distinct(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.Distinct((x, y) => x == y).SequenceEqual(expectedResult));

        [TestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 2, 3 })]
        public void DistinctWithHashCode(IEnumerable<int> source, IEnumerable<int> expectedResult)
        {
            var hash = GetHashCode();
            Assert.IsTrue(source.Distinct((x, y) => x == y, x => x.GetHashCode() ^ hash).SequenceEqual(expectedResult));
        }

        #endregion
    }
}
