using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class OrElseAsyncTest
    {
        #region Methods

        [TestMethod]
        public async Task OtherFactoryNullThrowsException()
        {
            var option = await OptionTask.None<int>();
            Func<Task<Option<int>>> otherFactory = null;

            await option
                .Awaiting(x => x.OrElseAsync(otherFactory))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, null, new int[0])]
        [DataRow(1, null, new[] { 1 })]
        [DataRow(null, 1, new[] { 1 })]
        [DataRow(1, 2, new[] { 1 })]
        public async Task OrElseAsync(int? source, int? other, IEnumerable<int> expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.OrElseAsync(() => other.ToOptionAsync());

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task OrElseAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .OrElseAsync(() => OptionTask.None<int>(), cts.Token)
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
