using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent.Tests.Nullables.Linq
{
    [TestClass]
    public sealed class SelectManyTest
    {
        #region Methods

        [TestMethod]
        public void SelectorNullThrowsException()
        {
            var source = new int?();
            Func<int, int?> selector = null;

            source.Invoking(x => x.SelectMany(selector)).ShouldThrow<ArgumentNullException>();
            source.Invoking(x => x.SelectMany(selector, (x, y) => x + y)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ResultSelectorNullThrowsException()
        {
            var source = new int?();
            Func<int, int, int> resultSelector = null;

            source.Invoking(x => x.SelectMany(x => x, resultSelector)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow(1, 1)]
        public void SelectMany(int? source, int? expectedResult)
            => source.SelectMany(x => new int?(x)).ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, null, null)]
        [DataRow(null, 0, null)]
        [DataRow(1, null, null)]
        [DataRow(1, 1, 2)]
        public void SelectManyWithResultSelector(int? source, int? selectorResult, int? expectedResult)
            => source.SelectMany(x => selectorResult, (x, y) => x + y).ShouldBe(expectedResult);

        #endregion
    }
}
