using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class ExceptTest
    {
        #region Methods

        [TestMethod]
        public void FirstNullThrowsException()
        {
            IEnumerable<int> first = null;
            var second = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentNullException>(() => first.Except(second, (x, y) => x == y));
        }

        [TestMethod]
        public void SecondNullThrowsException()
        {
            var first = new[] { 1, 2, 3 };
            IEnumerable<int> second = null;

            Assert.ThrowsException<ArgumentNullException>(() => first.Except(second, (x, y) => x == y));
        }

        [TestMethod]
        public void ComparerNullThrowsException()
        {
            var first = new[] { 1, 2, 3 };
            var second = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentNullException>(() => first.Except(second, null));
        }

        [TestMethod]
        [DataRow(new int[0], new int[0], new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new int[0])]
        [DataRow(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 1, 2, 3 })]
        public void Except(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> expectedResult)
            => Assert.IsTrue(first.Except(second, (x, y) => x == y).SequenceEqual(expectedResult));

        #endregion
    }
}
