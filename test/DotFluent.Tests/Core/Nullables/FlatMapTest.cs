using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent
{
    [TestFixture]
    public sealed class NullableFlatMapTest
    {
        #region Methods

        [Test]
        public void MapperNullThrowsException()
        {
            var source = new int?();
            Func<int, int?> mapper = null;

            source
                .Invoking(x => x.FlatMap(mapper))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(1, 1)]
        public void FlatMap(int? source, int? expectedResult)
            => source
                .FlatMap(x => new int?(x))
                .ShouldBe(expectedResult);

        #endregion
    }
}
