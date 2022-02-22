using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class OrElseAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.OrElseAsync(Option.None<int>()))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.OrElseAsync(Option.None<int>))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.OrElseAsync(OptionTask.None<int>))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task OtherFactoryNullThrowsException()
        {
            var optionTask = OptionTask.None<int>();
            Func<Option<int>> otherFactory = null;
            Func<Task<Option<int>>> taskOtherFactory = null;

            await optionTask
                .Awaiting(x => x.OrElseAsync(otherFactory))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.OrElseAsync(taskOtherFactory))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null, new int[0], 0)]
        [DataRow(null, null, new int[0], 1)]
        [DataRow(null, null, new int[0], 2)]
        [DataRow(1, null, new[] { 1 }, 0)]
        [DataRow(1, null, new[] { 1 }, 1)]
        [DataRow(1, null, new[] { 1 }, 2)]
        [DataRow(null, 1, new[] { 1 }, 0)]
        [DataRow(null, 1, new[] { 1 }, 1)]
        [DataRow(null, 1, new[] { 1 }, 2)]
        [DataRow(1, 2, new[] { 1 }, 0)]
        [DataRow(1, 2, new[] { 1 }, 1)]
        [DataRow(1, 2, new[] { 1 }, 2)]
        public async Task OrElseAsync(int? source, int? other, IEnumerable<int> expectedResult, int overload)
        {
            var optionTask = source.ToOptionAsync();
            var result = overload switch
            {
                1 => await optionTask.OrElseAsync(() => other.ToOption()),
                2 => await optionTask.OrElseAsync(() => other.ToOptionAsync()),
                _ => await optionTask.OrElseAsync(other.ToOption())
            };

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task OrElseAsyncCanceled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.OrElseAsync(Option.None<int>(), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.OrElseAsync(Option.None<int>, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.OrElseAsync(OptionTask.None<int>, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
