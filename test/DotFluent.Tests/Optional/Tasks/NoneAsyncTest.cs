using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class NoneAsyncTest
    {
        #region Methods

        [TestMethod]
        public async Task NoneAsync()
        {
            var result = await OptionTask.NoneAsync<int>();

            result.ShouldBe(Option<int>.None);
        }

        [TestMethod]
        public async Task NoneAsyncCancelled()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await Task.CompletedTask
                .Awaiting(_ => OptionTask.NoneAsync<int>(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
