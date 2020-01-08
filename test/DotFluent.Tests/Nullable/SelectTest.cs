using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent.Tests.Nullable
{
    [TestClass]
    public sealed class SelectTest
    {
        #region Methods

        [TestMethod]
        public void SelectorNullThrowsException()
        {
            var nullable = new int?();
            Func<int, int> selector = null;

            Assert.ThrowsException<ArgumentNullException>(() => nullable.Select(selector));
        }

        [TestMethod]
        public void Select()
        {
            var nullable = new int?();
            var result = nullable.Select(x => ++x);
            Assert.IsFalse(result.HasValue);

            nullable = 1;
            result = nullable.Select(x => ++x);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(result.Value, 2);
        }

        #endregion
    }
}
