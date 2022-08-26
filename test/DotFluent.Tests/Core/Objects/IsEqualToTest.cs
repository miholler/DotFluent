using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent
{
    [TestClass]
    public sealed class ObjectIsEqualToTest
    {
        #region Methods

        [TestMethod]
        public void IsEqual()
        {
            var a = 1;
            var b = 1;

            a.IsEqualTo(b).ShouldBeTrue();
        }

        [TestMethod]
        public void IsNotEqual()
        {
            var a = 1;
            var b = 2;

            a.IsEqualTo(b).ShouldBeFalse();
        }

        [TestMethod]
        public void IsReferenceEqual()
        {
            var a = new object();
            var b = a;

            a.IsEqualTo(b, true).ShouldBeTrue();
        }

        [TestMethod]
        public void IsReferenceNotEqual()
        {
            var a = new object();
            var b = new object();

            a.IsEqualTo(b, true).ShouldBeFalse();
        }

        #endregion
    }
}
