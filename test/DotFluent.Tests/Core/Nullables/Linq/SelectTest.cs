using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class NullableSelectTest
    {
        #region Methods

        [Test]
        public void SelectorNullThrowsException()
        {
            var source = new int?();
            Func<int, int> selector = null;

            source
                .Invoking(x => x.Select(selector))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(1, 1)]
        public void Select(int? source, int? expectedResult)
        {
            var result = from x in source
                         select x;

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
