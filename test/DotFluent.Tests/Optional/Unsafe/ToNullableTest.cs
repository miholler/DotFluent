using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Unsafe
{
    [TestFixture]
    public sealed class ToNullableTest
    {
        #region Methods

        [Test]
        [TestCase(null)]
        [TestCase(1)]
        public void ToNullable(int? source)
            => source
                .ToOption()
                .ToNullable()
                .ShouldBe(source);

        #endregion
    }
}
