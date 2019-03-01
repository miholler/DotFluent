using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.Object
{
    [TestClass]
    public sealed class IsEqualToTest
    {
        #region Methods

        [TestMethod]
        public void IsEqual()
        {
            var a = 1;
            var b = 1;

            Assert.IsTrue(a.IsEqualTo(b));
        }

        [TestMethod]
        public void IsNotEqual()
        {
            var a = 1;
            var b = 2;

            Assert.IsFalse(a.IsEqualTo(b));
        }

        [TestMethod]
        public void IsReferenceEqual()
        {
            var a = new object();
            var b = a;

            Assert.IsTrue(a.IsEqualTo(b, true));
        }

        [TestMethod]
        public void IsReferenceNotEqual()
        {
            var a = new object();
            var b = new object();

            Assert.IsFalse(a.IsEqualTo(b, true));
        }

        #endregion
    }
}
