using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableToNullableTest
    {
        #region Methods

        [TestMethod]
        [DataRow(1, 1)]
        public void ToNullable(int source, int? expectedResult)
            => source
                .ToNullable()
                .ShouldBe(expectedResult);

        #endregion
    }
}
