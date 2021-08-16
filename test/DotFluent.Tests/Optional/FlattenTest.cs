using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;

namespace DotFluent.Optional
{
    [TestClass]
    public sealed class FlattenTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public void Flatten(int? source, IEnumerable<int> expectedResult)
            => Option.Some(source.ToOption())
                .Flatten()
                .ShouldBe(expectedResult);

        #endregion
    }
}
