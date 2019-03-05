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
            var source = new Dictionary<int, int>(new GenericEqualityComparer<int>((x, y) => x == y));
            source.Add(0, 1);

            Assert.IsTrue(source.ContainsKey(0));
            Assert.IsFalse(source.ContainsKey(1));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            var source = new Dictionary<int, int>(new GenericEqualityComparer<int>((x, y) => x == y, x => x.GetHashCode()));
            source.Add(0, 1);

            Assert.IsTrue(source.ContainsKey(0));
            Assert.IsFalse(source.ContainsKey(1));
        }

        #endregion
    }
}
