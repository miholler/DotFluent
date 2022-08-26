using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent
{
    [TestClass]
    public sealed class ObjectIsNotNullTest
    {
        #region Methods

        [TestMethod]
        [DataRow(1, true)]
        [DataRow("", true)]
        [DataRow(null, false)]
        public void IsNotNull(object obj, bool expectedResult)
            => obj
                .IsNotNull()
                .ShouldBe(expectedResult);

        #endregion
    }
}
