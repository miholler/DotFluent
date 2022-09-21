using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class ExistsAsyncExtensionsTest
    {
        #region Methods

        [Test]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.ExistsAsync(_ => false))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false)))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task PredicateNullThrowsException()
        {
            var optionTask = OptionTask.None<int>();
            Func<int, bool> predicate = null;
            Func<int, Task<bool>> taskPredicate = null;

            await optionTask
                .Awaiting(x => x.ExistsAsync(predicate))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.ExistsAsync(taskPredicate))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, 1, false, 0)]
        [TestCase(null, 1, false, 1)]
        [TestCase(1, 2, false, 0)]
        [TestCase(1, 2, false, 1)]
        [TestCase(1, 1, true, 0)]
        [TestCase(1, 1, true, 1)]
        public async Task ExistsAsync(int? source, int value, bool expectedResult, int overload)
        {
            var optionTask = source.ToOptionAsync();
            var result = overload switch
            {
                1 => await optionTask.ExistsAsync(x => Task.FromResult(x == value)),
                _ => await optionTask.ExistsAsync(x => x == value)
            };

            result.ShouldBe(expectedResult);
        }

        [Test]
        public async Task ExistsAsyncCanceled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.ExistsAsync(_ => false, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
