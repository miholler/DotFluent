using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestClass]
    public sealed class IsNullOrEmptyTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, true)]
        [DataRow(new int[0], true)]
        [DataRow(new[] { 1 }, false)]
        public void IsNullOrEmpty(IEnumerable<int> source, bool expectedResult)
            => Assert.AreEqual(source.IsNullOrEmpty(), expectedResult);

        #endregion
    }
}
