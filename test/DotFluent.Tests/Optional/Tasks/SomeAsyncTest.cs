using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Threading;
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

        [TestMethod]
        public async Task SomeAsyncCanceled()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await Task.CompletedTask
                .Awaiting(_ => OptionTask.SomeAsync(0, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
