using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class SomeTest
    {
        #region Methods

        [TestMethod]
        public async Task Some()
        {
            var result = await OptionTask.Some(1);

            result.ShouldBe(Option<int>.Some(1));
        }

        #endregion
    }
}
