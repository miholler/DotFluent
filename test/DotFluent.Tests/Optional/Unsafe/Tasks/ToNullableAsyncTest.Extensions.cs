using DotFluent.Optional.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks
{
    [TestClass]
    public sealed class ToNullableAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.ToNullableAsync())
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow(1)]
        public async Task ToNullableAsync(int? source)
        {
            var result = await source
                .ToOptionAsync()
                .ToNullableAsync();

            result.ShouldBe(source);
        }

        [TestMethod]
        public async Task ToNullableAsyncCanceled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.ToNullableAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
