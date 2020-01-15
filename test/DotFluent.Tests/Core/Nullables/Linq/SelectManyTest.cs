using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent.Tests.Nullables.Linq
{
    [TestClass]
    public sealed class SelectManyTest
    {
        #region Methods

        [TestMethod]
        public void SelectorNullThrowsException()
        {
            var nullable = new int?();
            Func<int, int?> selector = null;

            Assert.ThrowsException<ArgumentNullException>(() => nullable.SelectMany(selector));
            Assert.ThrowsException<ArgumentNullException>(() => nullable.SelectMany(selector, (x, y) => x + y));
        }

        [TestMethod]
        public void ResultSelectorNullThrowsException()
        {
            var nullable = new int?();
            Func<int, int, int> resultSelector = null;

            Assert.ThrowsException<ArgumentNullException>(() => nullable.SelectMany(x => x, resultSelector));
        }

        [TestMethod]
        public void SelectMany()
        {
            var nullable = new int?();
            var result = nullable.SelectMany(x => new int?(x));
            Assert.IsFalse(result.HasValue);

            nullable = 1;
            result = nullable.SelectMany(x => new int?(x));
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(result.Value, 1);
        }

        [TestMethod]
        public void SelectManyWithResultSelector()
        {
            var nullable = new int?();
            var result = nullable.SelectMany(x => new int?(x), (x, y) => x + y);
            Assert.IsFalse(result.HasValue);

            nullable = 1;
            result = nullable.SelectMany(x => new int?(), (x, y) => x + y);
            Assert.IsFalse(result.HasValue);

            result = nullable.SelectMany(x => new int?(x), (x, y) => x + y);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(result.Value, 2);
        }

        #endregion
    }
}
