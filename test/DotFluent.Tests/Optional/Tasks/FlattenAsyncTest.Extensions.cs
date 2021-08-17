using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class FlattenAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<Option<Option<int>>> optionTask = null;

            await optionTask
                .Awaiting(x => x.FlattenAsync())
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult)
        {
            var result = await OptionTask.Some(await source.ToOptionAsync())
                .FlattenAsync();

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task FlattenAsyncCanceled()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await OptionTask.None<Option<int>>()
                .Awaiting(x => x.FlattenAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
