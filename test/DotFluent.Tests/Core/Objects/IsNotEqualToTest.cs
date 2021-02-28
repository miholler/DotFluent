using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent
{
    [TestClass]
    public sealed class ObjectIsNotEqualToTest
    {
        #region Methods

        [TestMethod]
        public void IsEqual()
        {
            var a = 1;
            var b = 1;

            Assert.IsFalse(a.IsNotEqualTo(b));
        }

        [TestMethod]
        public void IsNotEqual()
        {
            var a = 1;
            var b = 2;

            Assert.IsTrue(a.IsNotEqualTo(b));
        }

        [TestMethod]
        public void IsReferenceEqual()
        {
            var a = new object();
            var b = a;

            Assert.IsFalse(a.IsNotEqualTo(b, true));
        }

        [TestMethod]
        public void IsReferenceNotEqual()
        {
            var a = new object();
            var b = new object();

            Assert.IsTrue(a.IsNotEqualTo(b, true));
        }

        #endregion
    }
}
