using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent.Tests.Nullables
{
    [TestClass]
    public sealed class MapTest
    {
        #region Methods

        [TestMethod]
        public void MapperNullThrowsException()
        {
            var source = new int?();
            Func<int, int> mapper = null;

            source.Invoking(x => x.Map(mapper)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow(1, 2)]
        public void Map(int? source, int? expectedResult)
            => source.Map(x => ++x).ShouldBe(expectedResult);

        #endregion
    }
}
