using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class ObjectThrowIfNullTest
    {
        #region Methods

        [TestMethod]
        public void ObjectNullThrowsException()
        {
            object obj = null;

            Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIfNull(nameof(obj)));
        }

        [TestMethod]
        public void ObjectNullThrowsFactoryException()
        {
            object obj = null;

            Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIfNull(() => new ArgumentNullException(nameof(obj))));
        }

        [TestMethod]
        public void ObjectNotNullReturnsObject()
        {
            var obj = new object();

            Assert.AreSame(obj.ThrowIfNull(nameof(obj)), obj);
        }

        [TestMethod]
        public void ObjectNotNullReturnsObjectWithFactory()
        {
            var obj = new object();

            Assert.AreSame(obj.ThrowIfNull(() => new ArgumentNullException(nameof(obj))), obj);
        }

        #endregion
    }
}
