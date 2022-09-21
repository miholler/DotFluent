using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class MapAsyncExtensionsTest
    {
        #region Methods

        [Test]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.MapAsync(_ => 0))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MapAsync(_ => Task.FromResult(0)))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task MapperNullThrowsException()
        {
            var optionTask = OptionTask.None<int>();
            Func<int, int> mapper = null;
            Func<int, Task<int>> taskMapper = null;

            await optionTask
                .Awaiting(x => x.MapAsync(mapper))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MapAsync(taskMapper))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, new int[0], 0)]
        [TestCase(null, new int[0], 1)]
        [TestCase(1, new[] { 2 }, 0)]
        [TestCase(1, new[] { 2 }, 1)]
        public async Task MapAsync(int? source, IEnumerable<int> expectedResult, int overload)
        {
            var optionTask = source.ToOptionAsync();
            var result = overload switch
            {
                1 => await optionTask.MapAsync(x => Task.FromResult(++x)),
                _ => await optionTask.MapAsync(x => ++x)
            };

            result.ShouldBe(expectedResult);
        }

        [Test]
        public async Task MapAsyncCaneled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.MapAsync(_ => 0, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MapAsync(_ => Task.FromResult(0), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
