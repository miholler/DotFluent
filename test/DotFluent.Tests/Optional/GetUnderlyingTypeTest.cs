using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent.Optional
{
    [TestClass]
    public sealed class GetUnderlyingTypeTest
    {
        #region Methods

        [TestMethod]
        public void OptionTypeNullThrowsException()
        {
            Type type = null;

            type.Invoking(x => Option.GetUnderlyingType(x)).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(typeof(int), null)]
        [DataRow(typeof(Nullable<>), null)]
        [DataRow(typeof(int?), null)]
        [DataRow(typeof(Option<>), null)]
        [DataRow(typeof(Option<int>), typeof(int))]
        public void GetUnderlyingType(Type source, Type expectedResult)
            => Option.GetUnderlyingType(source).ShouldBe(expectedResult);

        #endregion
    }
}
