using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent.Tests.Nullables.Linq
{
    [TestClass]
    public sealed class SelectTest
    {
        #region Methods

        [TestMethod]
        public void SelectorNullThrowsException()
        {
            var source = new int?();
            Func<int, int> selector = null;

            source.Invoking(x => x.Select(selector)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow(1, 2)]
        public void Select(int? source, int? expectedResult)
            => source.Select(x => ++x).ShouldBe(expectedResult);

        #endregion
    }
}
