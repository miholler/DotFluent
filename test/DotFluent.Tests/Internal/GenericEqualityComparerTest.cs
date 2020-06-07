using DotFluent.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DotFluent.Tests.Internal
{
    [TestClass]
    public sealed class GenericEqualityComparerTest
    {
        #region Methods

        [TestMethod]
        public void EqualsTest()
        {
            var source = new Dictionary<int, int>(GenericEqualityComparer<int>.Create((x, y) => x == y))
            {
                { 0, 1 }
            };

            Assert.IsTrue(source.ContainsKey(0));
            Assert.IsFalse(source.ContainsKey(1));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            var source = new Dictionary<int, int>(GenericEqualityComparer<int>.Create((x, y) => x == y, x => x.GetHashCode()))
            {
                { 0, 1 }
            };

            Assert.IsTrue(source.ContainsKey(0));
            Assert.IsFalse(source.ContainsKey(1));
        }

        #endregion
    }
}
