using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class SomeTest
    {
        #region Methods

        [Test]
        public async Task Some()
        {
            var result = await OptionTask.Some(1);

            result.ShouldBe(Option<int>.Some(1));
        }

        #endregion
    }
}
