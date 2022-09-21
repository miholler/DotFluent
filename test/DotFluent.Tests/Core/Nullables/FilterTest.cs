using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent
{
    [TestFixture]
    public sealed class NullableFilterTest
    {
        #region Methods

        [Test]
        public void PredicateNullThrowsException()
        {
            var source = new int?();
            Func<int, bool> predicate = null;

            source
                .Invoking(x => x.Filter(predicate))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, 1, null)]
        [TestCase(1, 2, null)]
        [TestCase(1, 1, 1)]
        public void Filter(int? source, int value, int? expectedResult)
            => source
                .Filter(x => x == value)
                .ShouldBe(expectedResult);

        #endregion
    }
}
