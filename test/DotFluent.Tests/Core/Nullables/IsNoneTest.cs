using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableIsNoneTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, true)]
        [DataRow(1, false)]
        public void IsNone(int? source, bool expectedResult)
            => source
                .IsNone()
                .ShouldBe(expectedResult);

        #endregion
    }
}
