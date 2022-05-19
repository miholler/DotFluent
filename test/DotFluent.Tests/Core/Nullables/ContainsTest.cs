using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableContainsTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, 2, false)]
        [DataRow(1, 1, true)]
        public void Contains(int? source, int value, bool expectedResult)
            => source
                .Contains(value)
                .ShouldBe(expectedResult);

        #endregion
    }
}
