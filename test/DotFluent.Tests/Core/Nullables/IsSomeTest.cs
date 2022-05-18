using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableIsSomeTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, false)]
        [DataRow(1, true)]
        public void IsSome(int? source, bool expectedResult)
            => source
                .IsSome()
                .ShouldBe(expectedResult);

        #endregion
    }
}
