using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent.Tests.Nullables
{
    [TestClass]
    public sealed class FlatMapTest
    {
        #region Methods

        [TestMethod]
        public void MapperNullThrowsException()
        {
            var nullable = new int?();
            Func<int, int?> mapper = null;

            Assert.ThrowsException<ArgumentNullException>(() => nullable.FlatMap(mapper));
        }

        [TestMethod]
        public void FlatMap()
        {
            var nullable = new int?();
            var result = nullable.FlatMap(x => new int?(x));
            Assert.IsFalse(result.HasValue);

            nullable = 1;
            result = nullable.FlatMap(x => new int?(x));
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(result.Value, 1);
        }

        #endregion
    }
}
