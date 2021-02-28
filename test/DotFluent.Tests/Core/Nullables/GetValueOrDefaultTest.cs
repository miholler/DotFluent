using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class NullableGetValueOrDefaultTest
    {
        #region Methods

        [TestMethod]
        public void DefaultFactoryNullThrowsException()
        {
            var source = new int?();
            Func<int> defaultFactory = null;

            source.Invoking(x => x.GetValueOrDefault(defaultFactory)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, -1, -1)]
        [DataRow(1, -1, 1)]
        public void GetValueOrDefault(int? source, int defaultValue, int expectedResult)
            => source.GetValueOrDefault(() => defaultValue).ShouldBe(expectedResult);

        #endregion
    }
}
