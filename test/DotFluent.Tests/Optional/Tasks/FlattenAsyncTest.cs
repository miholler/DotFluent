using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class FlattenAsyncTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult)
        {
            var option = await OptionTask.Some(await source.ToOptionAsync());
            var result = await option.FlattenAsync();

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task FlattenAsyncCanceled()
        {
            var option = await OptionTask.None<Option<int>>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.FlattenAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
