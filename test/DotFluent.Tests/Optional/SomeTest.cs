using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional
{
    [TestFixture]
    public sealed class SomeTest
    {
        #region Methods

        [Test]
        public void Some()
            => Option.Some(1).ShouldBe(Option<int>.Some(1));

        #endregion
    }
}
