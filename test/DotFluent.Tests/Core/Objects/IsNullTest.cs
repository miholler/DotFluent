using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.Objects
{
    [TestClass]
    public sealed class IsNullTest
    {
        #region Methods

        [TestMethod]
        [DataRow(1, false)]
        [DataRow("", false)]
        [DataRow(null, true)]
        public void IsNull(object obj, bool expectedResult)
            => Assert.AreEqual(obj.IsNull(), expectedResult);

        #endregion
    }
}
