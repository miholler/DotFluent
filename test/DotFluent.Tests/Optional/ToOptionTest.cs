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
        [DataRow(null, new object[] { new string[0] })]
        [DataRow("ABC", new object[] { new[] { "ABC" } })]
        public void ToOptionReferenceType(string source, IEnumerable<string> expectedResult)
            => source
                .ToOption()
                .ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public void ToOptionValueType(int? source, IEnumerable<int> expectedResult)
            => source
                .ToOption()
                .ShouldBe(expectedResult);

        #endregion
    }
}
