using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class FilterAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.FilterAsync(_ => false))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.FilterAsync(_ => Task.FromResult(false)))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task PredicateNullThrowsException()
        {
            var optionTask = OptionTask.None<int>();
            Func<int, bool> predicate = null;
            Func<int, Task<bool>> taskPredicate = null;

            await optionTask
                .Awaiting(x => x.FilterAsync(predicate))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.FilterAsync(taskPredicate))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, new int[0], 0)]
        [DataRow(null, 1, new int[0], 1)]
        [DataRow(1, 2, new int[0], 0)]
        [DataRow(1, 2, new int[0], 1)]
        [DataRow(1, 1, new[] { 1 }, 0)]
        [DataRow(1, 1, new[] { 1 }, 1)]
        public async Task FilterAsync(int? source, int value, IEnumerable<int> expectedResult, int overload)
        {
            var optionTask = source.ToOptionAsync();
            var result = overload switch
            {
                1 => await optionTask.FilterAsync(x => Task.FromResult(x == value)),
                _ => await optionTask.FilterAsync(x => x == value)
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task FilterAsyncCanceled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.FilterAsync(_ => false, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.FilterAsync(_ => Task.FromResult(false), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
