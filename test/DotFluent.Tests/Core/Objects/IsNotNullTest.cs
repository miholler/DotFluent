using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotFluent.Tests.Objects
{
    [TestClass]
    public sealed class IsNotNullTest
    {
        #region Methods

        [TestMethod]
        [DataRow(1, true)]
        [DataRow("", true)]
        [DataRow(null, false)]
        public void IsNotNull(object obj, bool expectedResult)
            => Assert.AreEqual(obj.IsNotNull(), expectedResult);

        #endregion
    }
}
