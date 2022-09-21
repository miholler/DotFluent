using NUnit.Framework;
using Shouldly;

namespace DotFluent
{
    [TestFixture]
    public sealed class ObjectIsNullTest
    {
        #region Methods

        [Test]
        [TestCase(1, false)]
        [TestCase("", false)]
        [TestCase(null, true)]
        public void IsNull(object obj, bool expectedResult)
            => obj
                .IsNull()
                .ShouldBe(expectedResult);

        #endregion
    }
}
