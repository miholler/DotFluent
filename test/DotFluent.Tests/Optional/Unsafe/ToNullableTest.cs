using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent.Optional.Unsafe
{
    [TestClass]
    public sealed class ToNullableTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null)]
        [DataRow(1)]
        public void ToNullable(int? source)
            => source
                .ToOption()
                .ToNullable()
                .ShouldBe(source);

        #endregion
    }
}
