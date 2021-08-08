using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class FlatMapAsyncTest
    {
        #region Methods

        [TestMethod]
        public async Task MapperNullThrowsException()
        {
            var option = await OptionTask.None<int>();
            Func<int, Task<Option<int>>> mapper = null;

            await option
                .Awaiting(x => x.FlatMapAsync(mapper))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public async Task FlatMapAsync(int? source, IEnumerable<int> expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.FlatMapAsync(x => OptionTask.Some(x));

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task FlatMapAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.FlatMapAsync(y => OptionTask.Some(y), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
