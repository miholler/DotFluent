using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class FlattenAsyncTest
    {
        #region Methods

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(1, new[] { 1 })]
        public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult)
        {
            var option = await OptionTask.Some(await source.ToOptionAsync());
            var result = await option.FlattenAsync();

            result.ShouldBe(expectedResult);
        }

        [Test]
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
