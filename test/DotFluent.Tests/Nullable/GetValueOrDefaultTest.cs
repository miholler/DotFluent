using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent.Tests.Nullable
{
    [TestClass]
    public sealed class GetValueOrDefaultTest
    {
        #region Methods

        [TestMethod]
        public void DefaultFactoryNullThrowsException()
        {
            var nullable = new int?();

            Assert.ThrowsException<ArgumentNullException>(() => nullable.GetValueOrDefault(null));
        }

        [TestMethod]
        public void GetValueOrDefaultHasValue()
        {
            var nullable = new int?(1);
            var value = nullable.GetValueOrDefault(() => -1);

            Assert.AreEqual(value, 1);
        }

        [TestMethod]
        public void GetValueOrDefaultNoValue()
        {
            var nullable = new int?();
            var value = nullable.GetValueOrDefault(() => -1);

            Assert.AreEqual(value, -1);
        }

        #endregion
    }
}
