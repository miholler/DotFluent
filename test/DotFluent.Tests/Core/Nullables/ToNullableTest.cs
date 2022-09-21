using NUnit.Framework;
using Shouldly;

namespace DotFluent
{
    [TestFixture]
    public sealed class NullableToNullableTest
    {
        #region Methods

        [Test]
        [TestCase(1, 1)]
        public void ToNullable(int source, int? expectedResult)
            => source
                .ToNullable()
                .ShouldBe(expectedResult);

        #endregion
    }
}
