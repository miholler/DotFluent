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
            Task<Option<int>> source = null;

            await source
                .Awaiting(x => x.ContainsAsync(0))
                .ShouldThrowAsync<ArgumentNullException>();
            await source
                .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0)))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task ValueFactoryNullThrowsException()
        {
            var source = OptionTask.None<int>();
            Func<Task<int>> valueFactory = null;

            await source
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
            var sourceTask = source.ToOptionAsync();
            var result = overload switch
            {
                1 => await sourceTask.ContainsAsync(() => Task.FromResult(value)),
                _ => await sourceTask.ContainsAsync(value)
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task ContainsAsyncCanceled()
        {
            var source = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await source
                .Awaiting(x => x.ContainsAsync(0, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await source
                .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
