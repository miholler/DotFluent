using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class FlatMapAsyncExtensionsTest
    {
        #region Methods

        [Test]
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

        [Test]
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

        [Test]
        [TestCase(null, new int[0], 0)]
        [TestCase(null, new int[0], 1)]
        [TestCase(1, new[] { 1 }, 0)]
        [TestCase(1, new[] { 1 }, 1)]
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

        [Test]
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
