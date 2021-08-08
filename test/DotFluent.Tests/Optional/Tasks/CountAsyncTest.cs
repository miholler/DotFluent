using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class CountAsyncTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, 0)]
        [DataRow(1, 1)]
        public async Task CountAsync(int? source, int expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.CountAsync();

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task CountAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.CountAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
