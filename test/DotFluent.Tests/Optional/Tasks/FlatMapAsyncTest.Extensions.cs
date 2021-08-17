using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class FlatMapAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.FlatMapAsync(_ => Option.None<int>()))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.FlatMapAsync(_ => OptionTask.None<int>()))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task MapperNullThrowsException()
        {
            var optionTask = OptionTask.None<int>();
            Func<int, Option<int>> mapper = null;
            Func<int, Task<Option<int>>> taskMapper = null;

            await optionTask
                .Awaiting(x => x.FlatMapAsync(mapper))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.FlatMapAsync(taskMapper))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, new int[0], 0)]
        [DataRow(null, new int[0], 1)]
        [DataRow(1, new[] { 1 }, 0)]
        [DataRow(1, new[] { 1 }, 1)]
        public async Task FlatMapAsync(int? source, IEnumerable<int> expectedResult, int overload)
        {
            var optionTask = source.ToOptionAsync();
            var result = overload switch
            {
                1 => await optionTask.FlatMapAsync(x => OptionTask.Some(x)),
                _ => await optionTask.FlatMapAsync(x => Option.Some(x))
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task FlatMapAsyncCanceled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.FlatMapAsync(_ => Option.None<int>(), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.FlatMapAsync(_ => OptionTask.None<int>(), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
