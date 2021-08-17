using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class ToOptionAsyncTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public async Task ToOptionAsync(int? source, IEnumerable<int> expectedResult)
        {
            var result = await source.ToOptionAsync();

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task ToOptionAsyncCanceled()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await Task.CompletedTask
                .Awaiting(_ => new int?().ToOptionAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
