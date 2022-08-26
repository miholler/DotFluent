using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class OrElseAsyncTest
    {
        #region Methods

        [Test]
        public async Task OtherFactoryNullThrowsException()
        {
            var option = await OptionTask.None<int>();
            Func<Task<Option<int>>> otherFactory = null;

            await option
                .Awaiting(x => x.OrElseAsync(otherFactory))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task OtherFactoryReturningNullThrowsException()
        {
            var option = await OptionTask.None<int>();

            await option
                .Awaiting(x => x.OrElseAsync(() => null))
                .ShouldThrowAsync<InvalidOperationException>();
        }

        [Test]
        [TestCase(null, null, new int[0])]
        [TestCase(1, null, new[] { 1 })]
        [TestCase(null, 1, new[] { 1 })]
        [TestCase(1, 2, new[] { 1 })]
        public async Task OrElseAsync(int? source, int? other, IEnumerable<int> expectedResult)
        {
            var option = await source.ToOptionAsync();
            var result = await option.OrElseAsync(() => other.ToOptionAsync());

            result.ShouldBe(expectedResult);
        }

        [Test]
        public async Task OrElseAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .OrElseAsync(() => OptionTask.None<int>(), cts.Token)
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
