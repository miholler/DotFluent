using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableFilterTest
    {
        #region Methods

        [TestMethod]
        public void PredicateNullThrowsException()
        {
            var source = new int?();
            Func<int, bool> predicate = null;

            source
                .Invoking(x => x.Filter(predicate))
                .ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, null)]
        [DataRow(1, 2, null)]
        [DataRow(1, 1, 1)]
        public void Filter(int? source, int value, int? expectedResult)
            => source
                .Filter(x => x == value)
                .ShouldBe(expectedResult);

        #endregion
    }
}
