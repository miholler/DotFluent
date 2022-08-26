using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class CountAsyncTest
    {
        #region Methods

        [Test]
        [TestCase(null, 0)]
        [TestCase(1, 1)]
        public async Task CountAsync(int? source, int expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.CountAsync();

            result.ShouldBe(expectedResult);
        }

        [Test]
        public async Task CountAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.CountAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
