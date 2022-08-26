using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent
{
    [TestFixture]
    public sealed class ObjectMapTest
    {
        #region Methods

        [Test]
        public void MapperNullThrowsException()
        {
            var obj = new object();
            Func<object, object> mapper = null;

            obj.Invoking(x => x.Map(mapper))
               .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("ABC", "ABC!")]
        public void Map(string source, string expectedResult)
            => source
                .Map(x => $"{x}!")
                .ShouldBe(expectedResult);

        #endregion
    }
}
