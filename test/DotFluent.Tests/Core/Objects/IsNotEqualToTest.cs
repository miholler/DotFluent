using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

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

            a.IsNotEqualTo(b).ShouldBeFalse();
        }

        [TestMethod]
        public void IsNotEqual()
        {
            var a = 1;
            var b = 2;

            a.IsNotEqualTo(b).ShouldBeTrue();
        }

        [TestMethod]
        public void IsReferenceEqual()
        {
            var a = new object();
            var b = a;

            a.IsNotEqualTo(b, true).ShouldBeFalse();
        }

        [TestMethod]
        public void IsReferenceNotEqual()
        {
            var a = new object();
            var b = new object();

            a.IsNotEqualTo(b, true).ShouldBeTrue();
        }

        #endregion
    }
}
