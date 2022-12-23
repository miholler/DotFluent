using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class NullableSelectManyTest
    {
        #region Methods

        [Test]
        public void SelectorNullThrowsException()
        {
            var source = new int?();
            Func<int, int?> selector = null;

            source
                .Invoking(x => x.SelectMany(selector))
                .ShouldThrow<ArgumentNullException>();
            source
                .Invoking(x => x.SelectMany(selector, (y, z) => y + z))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ResultSelectorNullThrowsException()
        {
            var source = new int?();
            Func<int, int, int> resultSelector = null;

            source
                .Invoking(x => x.SelectMany(y => y, resultSelector))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(1, 1)]
        public void SelectMany(int? source, int? expectedResult)
            => source
                .SelectMany(x => x.ToNullable())
                .ShouldBe(expectedResult);

        [Test]
        [TestCase(null, null, null)]
        [TestCase(null, 1, null)]
        [TestCase(1, null, null)]
        [TestCase(1, 1, 2)]
        public void SelectManyWithResultSelector(int? source, int? selectorResult, int? expectedResult)
        {
            var result = from x in source
                         from y in selectorResult
                         select x + y;

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
