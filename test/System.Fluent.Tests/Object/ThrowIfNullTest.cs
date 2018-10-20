using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Fluent.Tests.Object
{
    [TestClass]
    public sealed class ThrowIfNullTest
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

            Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIfNull(() => new ArgumentNullException("obj")));
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

            Assert.AreSame(obj.ThrowIfNull(() => new ArgumentNullException("obj")), obj);
        }

        #endregion
    }
}
