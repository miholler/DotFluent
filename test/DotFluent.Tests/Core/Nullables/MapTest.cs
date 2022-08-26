using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableMapTest
    {
        #region Methods

        [TestMethod]
        public void MapperNullThrowsException()
        {
            var source = new int?();
            Func<int, int> mapper = null;

            source
                .Invoking(x => x.Map(mapper))
                .ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow(1, 2)]
        public void Map(int? source, int? expectedResult)
            => source
                .Map(x => ++x)
                .ShouldBe(expectedResult);

        #endregion
    }
}
