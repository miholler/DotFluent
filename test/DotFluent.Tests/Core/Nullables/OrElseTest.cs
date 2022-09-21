using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent
{
    [TestFixture]
    public sealed class NullableOrElseTest
    {
        #region Methods

        [Test]
        public void OtherFactoryNullThrowsException()
        {
            var source = new int?();
            Func<int?> otherFactory = null;

            source
                .Invoking(x => x.OrElse(otherFactory))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, null, null, 0)]
        [TestCase(null, null, null, 1)]
        [TestCase(1, null, 1, 0)]
        [TestCase(1, null, 1, 1)]
        [TestCase(null, 1, 1, 0)]
        [TestCase(null, 1, 1, 1)]
        [TestCase(1, 2, 1, 0)]
        [TestCase(1, 2, 1, 1)]
        public void OrElse(int? source, int? other, int? expectedResult, int overload)
        {
            var result = overload switch
            {
                1 => source.OrElse(() => other),
                _ => source.OrElse(other)
            };

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
