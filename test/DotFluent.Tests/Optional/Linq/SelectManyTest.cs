using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Optional.Linq
{
    [TestClass]
    public sealed class SelectManyTest
    {
        #region Methods

        [TestMethod]
        public void SelectorNullThrowsException()
        {
            var option = Option.None<int>();
            Func<int, Option<int>> selector = null;

            option.Invoking(x => x.SelectMany(selector)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ResultSelectorNullThrowsException()
        {
            var option = Option.None<int>();
            Func<int, int, int> resultSelector = null;

            option.Invoking(x => x.SelectMany(y => Option.Some(y), resultSelector)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public void SelectMany(int? source, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .SelectMany(x => Option.Some(x))
                .ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, null, new int[0])]
        [DataRow(null, 0, new int[0])]
        [DataRow(1, null, new int[0])]
        [DataRow(1, 1, new[] { 2 })]
        public void SelectManyWithResultSelector(int? source, int? selectorResult, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .SelectMany(x => selectorResult.ToOption(), (x, y) => x + y)
                .ShouldBe(expectedResult);

        #endregion
    }
}
