using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace DotFluent.Optional
{
    [TestClass]
    public sealed class SomeTest
    {
        #region Methods

        [TestMethod]
        public void Some()
            => Option.Some(1).ShouldBe(Option<int>.Some(1));

        #endregion
    }
}
