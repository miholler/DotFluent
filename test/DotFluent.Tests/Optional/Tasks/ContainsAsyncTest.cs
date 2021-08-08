using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class ContainsAsyncTest
    {
        #region Methods

        [TestMethod]
        public async Task ValueFactoryNullThrowsException()
        {
            var option = await OptionTask.NoneAsync<int>();
            Func<Task<int>> valueFactory = null;

            await option
                .Awaiting(x => x.ContainsAsync(valueFactory))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task ValueFactoryReturningNullThrowsException()
        {
            var option = await OptionTask.NoneAsync<int>();

            await option
                .Awaiting(x => x.ContainsAsync(() => null))
                .ShouldThrowAsync<NullReferenceException>();
        }

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, 2, false)]
        [DataRow(1, 1, true)]
        public async Task ContainsAsync(int? source, int value, bool expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.ContainsAsync(() => Task.FromResult(value));

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task ContainsAsyncCanceled()
        {
            var option = await OptionTask.NoneAsync<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        [TestMethod]
        public async Task ContainsAsyncValueFactoryCanceled()
        {
            var option = await OptionTask.NoneAsync<int>();
            var cts = new CancellationTokenSource();

            await option
                .Awaiting(x => x.ContainsAsync(() =>
                {
                    cts.Cancel();
                    return Task.FromResult(0);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
