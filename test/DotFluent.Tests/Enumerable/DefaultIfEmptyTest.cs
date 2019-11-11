using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class DefaultIfEmptyTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.DefaultIfEmpty(() => 0).ToArray());
        }

        [TestMethod]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new int[0];

            Assert.ThrowsException<ArgumentNullException>(() => source.DefaultIfEmpty(null).ToArray());
        }

        [TestMethod]
        [DataRow(new int[0], new[] { 0 })]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        public void DefaultIfEmpty(IEnumerable<int> source, IEnumerable<int> expectedResult)
            => Assert.IsTrue(source.DefaultIfEmpty(() => 0).SequenceEqual(expectedResult));

        #endregion
    }
}
