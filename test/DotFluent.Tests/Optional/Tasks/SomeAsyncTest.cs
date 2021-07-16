using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class SomeAsyncTest
    {
        #region Methods

        [TestMethod]
        public async Task SomeAsync()
        {
            var result = await OptionTask.SomeAsync(1);
            result.ShouldBe(Option<int>.Some(1));
        }

        #endregion
    }
}
