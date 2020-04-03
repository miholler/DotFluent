using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class IsNotNullOrEmptyTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, false)]
        [DataRow(new int[0], false)]
        [DataRow(new[] { 1 }, true)]
        public void IsNotNullOrEmpty(IEnumerable<int> source, bool expectedResult)
            => Assert.AreEqual(source.IsNotNullOrEmpty(), expectedResult);

        #endregion
    }
}
