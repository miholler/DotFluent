using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class CountAsyncExtensionsTest
    {
        #region Methods

        [Test]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.CountAsync())
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(1, 1)]
        public async Task CountAsync(int? source, int expectedResult)
        {
            var result = await source
                .ToOptionAsync()
                .CountAsync();

            result.ShouldBe(expectedResult);
        }

        [Test]
        public async Task CountAsyncCanceled()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await OptionTask.None<int>()
                .Awaiting(x => x.CountAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
