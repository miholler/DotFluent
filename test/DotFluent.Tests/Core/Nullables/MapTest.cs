using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent.Tests.Nullables
{
    [TestClass]
    public sealed class MapTest
    {
        #region Methods

        [TestMethod]
        public void MapperNullThrowsException()
        {
            var nullable = new int?();
            Func<int, int> mapper = null;

            Assert.ThrowsException<ArgumentNullException>(() => nullable.Map(mapper));
        }

        [TestMethod]
        public void Map()
        {
            var nullable = new int?();
            var result = nullable.Map(x => ++x);
            Assert.IsFalse(result.HasValue);

            nullable = 1;
            result = nullable.Map(x => ++x);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(result.Value, 2);
        }

        #endregion
    }
}
