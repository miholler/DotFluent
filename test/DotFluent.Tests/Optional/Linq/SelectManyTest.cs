using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Optional.Linq
{
    [TestFixture]
    public sealed class SelectManyTest
    {
        #region Methods

        [Test]
        public void SelectorNullThrowsException()
        {
            var option = Option.None<int>();
            Func<int, Option<int>> selector = null;

            option
                .Invoking(x => x.SelectMany(selector))
                .ShouldThrow<ArgumentNullException>();
            option
                .Invoking(x => x.SelectMany(selector, (y, z) => y + z))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ResultSelectorNullThrowsException()
        {
            var option = Option.None<int>();
            Func<int, int, int> resultSelector = null;

            option
                .Invoking(x => x.SelectMany(Option.Some, resultSelector))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(1, new[] { 1 })]
        public void SelectMany(int? source, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .SelectMany(Option.Some)
                .ShouldBe(expectedResult);

        [Test]
        [TestCase(null, null, new int[0])]
        [TestCase(null, 1, new int[0])]
        [TestCase(1, null, new int[0])]
        [TestCase(1, 1, new[] { 2 })]
        public void SelectManyWithResultSelector(int? source, int? selectorResult, IEnumerable<int> expectedResult)
        {
            var result = from x in source.ToOption()
                         from y in selectorResult.ToOption()
                         select x + y;

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
