using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class FlattenAsyncExtensionsTest
    {
        #region Methods

        [Test]
        public async Task SourceNullThrowsException()
        {
            Task<Option<Option<int>>> optionTask = null;

            await optionTask
                .Awaiting(x => x.FlattenAsync())
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(1, new[] { 1 })]
        public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult)
        {
            var result = await OptionTask.Some(await source.ToOptionAsync())
                .FlattenAsync();

            result.ShouldBe(expectedResult);
        }

        [Test]
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
