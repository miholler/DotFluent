using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Optional.Linq
{
    [TestClass]
    public sealed class SelectTest
    {
        #region Methods

        [TestMethod]
        public void SelectorNullThrowsException()
        {
            var option = Option.None<int>();
            Func<int, int> selector = null;

            option.Invoking(x => x.Select(selector)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 2 })]
        public void Select(int? source, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .Select(x => ++x)
                .ShouldBe(expectedResult);

        #endregion
    }
}
