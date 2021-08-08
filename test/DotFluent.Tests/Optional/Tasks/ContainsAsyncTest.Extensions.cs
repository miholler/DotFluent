using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class ContainsAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.ContainsAsync(0))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0)))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task ValueFactoryNullThrowsException()
        {
            var optionTask = OptionTask.None<int>();
            Func<Task<int>> valueFactory = null;

            await optionTask
                .Awaiting(x => x.ContainsAsync(valueFactory))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, false, 0)]
        [DataRow(null, 1, false, 1)]
        [DataRow(1, 2, false, 0)]
        [DataRow(1, 2, false, 1)]
        [DataRow(1, 1, true, 0)]
        [DataRow(1, 1, true, 1)]
        public async Task ContainsAsync(int? source, int value, bool expectedResult, int overload)
        {
            var optionTask = source.ToOptionAsync();
            var result = overload switch
            {
                1 => await optionTask.ContainsAsync(() => Task.FromResult(value)),
                _ => await optionTask.ContainsAsync(value)
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task ContainsAsyncCanceled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.ContainsAsync(0, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
