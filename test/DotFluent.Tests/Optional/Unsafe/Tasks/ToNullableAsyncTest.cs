using DotFluent.Optional.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks
{
    [TestClass]
    public sealed class ToNullableAsyncTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null)]
        [DataRow(1)]
        public async Task ToNullableAsync(int? source)
        {
            var result = await source
                .ToOption()
                .ToNullableAsync();

            result.ShouldBe(source);
        }

        [TestMethod]
        public async Task ToNullableAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.ToNullableAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
