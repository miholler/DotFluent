using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class MapAsyncTest
    {
        #region Methods

        [TestMethod]
        public async Task MapperNullThrowsException()
        {
            var option = await OptionTask.None<int>();
            Func<int, Task<int>> mapper = null;

            await option
                .Awaiting(x => x.MapAsync(mapper))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task MapperReturningNullThrowsException()
        {
            var option = await OptionTask.Some(0);

            await option
                .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
                .ShouldThrowAsync<InvalidOperationException>();
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 2 })]
        public async Task MapAsync(int? source, IEnumerable<int> expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.MapAsync(x => Task.FromResult(++x));

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task MapAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.MapAsync(y => Task.FromResult(y), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        [TestMethod]
        public async Task MapAsyncMappingCanceled()
        {
            var option = await OptionTask.Some(0);
            using var cts = new CancellationTokenSource();

            await option
                .Awaiting(x => x.MapAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
