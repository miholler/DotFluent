using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent
{
    [TestClass]
    public sealed class ObjectIsNullTest
    {
        #region Methods

        [TestMethod]
        [DataRow(1, false)]
        [DataRow("", false)]
        [DataRow(null, true)]
        public void IsNull(object obj, bool expectedResult)
            => obj
                .IsNull()
                .ShouldBe(expectedResult);

        #endregion
    }
}
