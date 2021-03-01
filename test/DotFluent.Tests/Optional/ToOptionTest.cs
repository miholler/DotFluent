using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;

namespace DotFluent.Optional
{
    [TestClass]
    public sealed class ToOptionTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public void ToOption(int? source, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .ShouldBe(expectedResult);

        #endregion
    }
}
