using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableFlatMapTest
    {
        #region Methods

        [TestMethod]
        public void MapperNullThrowsException()
        {
            var source = new int?();
            Func<int, int?> mapper = null;

            source
                .Invoking(x => x.FlatMap(mapper))
                .ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow(1, 1)]
        public void FlatMap(int? source, int? expectedResult)
            => source
                .FlatMap(x => new int?(x))
                .ShouldBe(expectedResult);

        #endregion
    }
}
