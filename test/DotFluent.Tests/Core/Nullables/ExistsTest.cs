using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent
{
    [TestFixture]
    public sealed class NullableExistsTest
    {
        #region Methods

        [Test]
        public void PredicateNullThrowsException()
        {
            var source = new int?();
            Func<int, bool> predicate = null;

            source
                .Invoking(x => x.Exists(predicate))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, 1, false)]
        [TestCase(1, 2, false)]
        [TestCase(1, 1, true)]
        public void Exists(int? source, int value, bool expectedResult)
            => source
                .Exists(x => x == value)
                .ShouldBe(expectedResult);

        #endregion
    }
}
