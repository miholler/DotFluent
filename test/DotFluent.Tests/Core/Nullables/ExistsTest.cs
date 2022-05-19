using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableExistsTest
    {
        #region Methods

        [TestMethod]
        public void PredicateNullThrowsException()
        {
            var source = new int?();
            Func<int, bool> predicate = null;

            source
                .Invoking(x => x.Exists(predicate))
                .ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, 2, false)]
        [DataRow(1, 1, true)]
        public void Exists(int? source, int value, bool expectedResult)
            => source
                .Exists(x => x == value)
                .ShouldBe(expectedResult);

        #endregion
    }
}
