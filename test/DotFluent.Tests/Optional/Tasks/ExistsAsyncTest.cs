using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class ExistsAsyncTest
    {
        #region Methods

        [TestMethod]
        public async Task PredicateNullThrowsException()
        {
            var option = await OptionTask.None<int>();
            Func<int, Task<bool>> predicate = null;

            await option
                .Awaiting(x => x.ExistsAsync(predicate))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task PredicateReturningNullThrowsException()
        {
            var option = await OptionTask.Some(0);

            await option
                .Awaiting(x => x.ExistsAsync(_ => null))
                .ShouldThrowAsync<InvalidOperationException>();
        }

        [TestMethod]
        [DataRow(null, 1, false)]
        [DataRow(1, 2, false)]
        [DataRow(1, 1, true)]
        public async Task ExistsAsync(int? source, int value, bool expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.ExistsAsync(x => Task.FromResult(x == value));

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task ExistsAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
