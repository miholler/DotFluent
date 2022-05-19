using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableOrElseTest
    {
        #region Methods

        [TestMethod]
        public void OtherFactoryNullThrowsException()
        {
            var source = new int?();
            Func<int?> otherFactory = null;

            source
                .Invoking(x => x.OrElse(otherFactory))
                .ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null, null, 0)]
        [DataRow(null, null, null, 1)]
        [DataRow(1, null, 1, 0)]
        [DataRow(1, null, 1, 1)]
        [DataRow(null, 1, 1, 0)]
        [DataRow(null, 1, 1, 1)]
        [DataRow(1, 2, 1, 0)]
        [DataRow(1, 2, 1, 1)]
        public void OrElse(int? source, int? other, int? expectedResult, int overload)
        {
            var result = overload switch
            {
                1 => source.OrElse(() => other),
                _ => source.OrElse(other)
            };

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
