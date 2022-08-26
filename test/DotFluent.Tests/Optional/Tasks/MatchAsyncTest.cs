using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestFixture]
    public sealed class MatchAsyncTest
    {
        #region Methods

        [Test]
        public async Task NoneNullThrowsException()
        {
            var option = await OptionTask.None<int>();
            Func<Task> none = null;
            Func<Task<int>> noneValue = null;

            await option
                .Awaiting(x => x.MatchAsync(none))
                .ShouldThrowAsync<ArgumentNullException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, none))
                .ShouldThrowAsync<ArgumentNullException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), noneValue))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task SomeNullThrowsException()
        {
            var option = await OptionTask.Some(0);
            Func<int, Task> some = null;
            Func<int, Task<int>> someValue = null;

            await option
                .Awaiting(x => x.MatchAsync(some))
                .ShouldThrowAsync<ArgumentNullException>();
            await option
                .Awaiting(x => x.MatchAsync(some, () => Task.CompletedTask))
                .ShouldThrowAsync<ArgumentNullException>();
            await option
                .Awaiting(x => x.MatchAsync(someValue, 0))
                .ShouldThrowAsync<ArgumentNullException>();
            await option
                .Awaiting(x => x.MatchAsync(someValue, () => Task.FromResult(0)))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task NoneReturningNullThrowsException()
        {
            var option = await OptionTask.None<int>();

            await option
                .Awaiting(x => x.MatchAsync(() => null))
                .ShouldThrowAsync<InvalidOperationException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => null))
                .ShouldThrowAsync<InvalidOperationException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => null))
                .ShouldThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task SomeReturningNullThrowsException()
        {
            var option = await OptionTask.Some(0);

            await option
                .Awaiting(x => x.MatchAsync(_ => null))
                .ShouldThrowAsync<InvalidOperationException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => null, () => Task.CompletedTask))
                .ShouldThrowAsync<InvalidOperationException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => null, 0))
                .ShouldThrowAsync<InvalidOperationException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => null, () => Task.FromResult(0)))
                .ShouldThrowAsync<InvalidOperationException>();
        }

        [Test]
        [TestCase(null, 1, 1, 0)]
        [TestCase(1, 0, 0, 0)]
        [TestCase(null, 0, 0, 1)]
        [TestCase(1, 1, 2, 1)]
        [TestCase(1, 1, 2, 2)]
        [TestCase(null, 1, 1, 2)]
        [TestCase(1, 1, 2, 3)]
        [TestCase(null, 1, 1, 3)]
        [TestCase(1, 1, 2, 4)]
        [TestCase(null, 1, 1, 4)]
        public async Task MatchAsync(int? source, int value, int expectedResult, int overload)
        {
            var result = 0;
            var option = await source.ToOptionAsync();

            switch (overload)
            {
                case 1:
                    await option.MatchAsync(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    });
                    break;
                case 2:
                    await option.MatchAsync(x => 
                    { 
                        result = x + value;
                        return Task.CompletedTask;
                    }, () => 
                    { 
                        result = value;
                        return Task.CompletedTask;
                    });
                    break;
                case 3:
                    result = await option.MatchAsync(x => Task.FromResult(x + value), value);
                    break;
                case 4:
                    result = await option.MatchAsync(x => Task.FromResult(x + value), () => Task.FromResult(value));
                    break;
                default:
                    await option.MatchAsync(() =>
                    { 
                        result = value;
                        return Task.CompletedTask;
                    });
                    break;
            }
            result.ShouldBe(expectedResult);
        }

        [Test]
        public async Task MatchAsyncCanceled()
        {
            var option = await OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await option
                .Awaiting(x => x.MatchAsync(() => Task.CompletedTask, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => Task.CompletedTask, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), 0, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await option
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => Task.FromResult(0), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
