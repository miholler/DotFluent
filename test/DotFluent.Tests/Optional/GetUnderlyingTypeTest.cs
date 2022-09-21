using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent.Optional
{
    [TestFixture]
    public sealed class GetUnderlyingTypeTest
    {
        #region Methods

        [Test]
        public void OptionTypeNullThrowsException()
        {
            Type type = null;

            type.Invoking(x => Option.GetUnderlyingType(x)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(typeof(int), null)]
        [TestCase(typeof(Nullable<>), null)]
        [TestCase(typeof(int?), null)]
        [TestCase(typeof(Option<>), null)]
        [TestCase(typeof(Option<int>), typeof(int))]
        public void GetUnderlyingType(Type source, Type expectedResult)
            => Option.GetUnderlyingType(source).ShouldBe(expectedResult);

        #endregion
    }
}
