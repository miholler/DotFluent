using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent.Optional
{
    [TestClass]
    public sealed class NoneTest
    {
        #region Methods

        [TestMethod]
        public void None()
            => Option.None<int>().ShouldBe(Option<int>.None);

        #endregion
    }
}
