using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class SecureAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.SecureAsync())
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task SecureAsync()
        {
            var optionTask = OptionTask.Some<object>(null);
            var result = await optionTask.SecureAsync();

            result.ShouldBe(Option<object>.None);
        }

        [TestMethod]
        public async Task SecureAsyncCanceled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.SecureAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
