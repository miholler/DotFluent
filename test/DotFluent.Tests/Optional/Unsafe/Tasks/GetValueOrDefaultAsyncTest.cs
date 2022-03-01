using DotFluent.Optional.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks
{
    [TestClass]
    public sealed class GetValueOrDefaultAsyncTest
    {
        #region Methods

        [TestMethod]
        public async Task DefaultFactoryNullThrowsException()
        {
            var option = await OptionTask.None<int>();
            Func<Task<int>> defaultFactory = null;

            await option
                .Awaiting(x => x.GetValueOrDefaultAsync(defaultFactory))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, 1)]
        [DataRow(1, 2, 1)]
        public async Task GetValueOrDefaultAsync(int? source, int defaultValue, int expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.GetValueOrDefaultAsync(() => Task.FromResult(defaultValue));

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task GetValueOrDefaultAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
