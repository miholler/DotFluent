using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent.Optional.Unsafe
{
    [TestClass]
    public sealed class GetValueOrDefaultTest
    {
        #region Methods

        [TestMethod]
        public void DefaultFactoryNullThrowsExcption()
        {
            var option = Option.None<int>();
            Func<int> defaultFactory = null;

            option.Invoking(x => x.GetValueOrDefault(defaultFactory)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 0)]
        [DataRow(1, 1)]
        public void GetValueOrDefault(int? source, int expectedResult)
            => source
                .ToOption()
                .GetValueOrDefault()
                .ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, 1, 1)]
        [DataRow(1, 2, 1)]
        public void GetValueOrDefaultWithDefaultValue(int? source, int defaultValue, int expectedResult)
            => source
                .ToOption()
                .GetValueOrDefault(defaultValue)
                .ShouldBe(expectedResult);

        [TestMethod]
        [DataRow(null, 1, 1)]
        [DataRow(1, 2, 1)]
        public void GetValueOrDefaultWithDefaultFactory(int? source, int defaultValue, int expectedResult)
            => source
                .ToOption()
                .GetValueOrDefault(() => defaultValue)
                .ShouldBe(expectedResult);

        #endregion
    }
}
