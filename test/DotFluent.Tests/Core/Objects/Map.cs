using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class ObjectMapTest
    {
        #region Methods

        [TestMethod]
        public void MapperNullThrowsException()
        {
            var obj = new object();
            Func<object, object> mapper = null;

            obj.Invoking(x => x.Map(mapper))
               .ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow("ABC", "ABC!")]
        public void Map(string source, string expectedResult)
            => source
                .Map(x => $"{x}!")
                .ShouldBe(expectedResult);

        #endregion
    }
}
