using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class MatchAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<Option<int>> optionTask = null;

            await optionTask
                .Awaiting(x => x.MatchAsync(() => { }))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(() => Task.CompletedTask))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => { }))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => { }, () => { }))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => Task.CompletedTask))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => 0, 0))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), 0))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => 0, () => 0))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => Task.FromResult(0)))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task NoneNullThrowsException()
        {
            var optionTask = OptionTask.None<int>();
            Action none = null;
            Func<int> noneValue = null;
            Func<Task> taskNone = null;
            Func<Task<int>> taskNoneValue = null;

            await optionTask
                .Awaiting(x => x.MatchAsync(none))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(taskNone))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => { }, none))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, taskNone))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => 0, noneValue))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), taskNoneValue))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task SomeNullThrowsException()
        {
            var optionTask = OptionTask.None<int>();
            Action<int> some = null;
            Func<int, int> someValue = null;
            Func<int, Task> taskSome = null;
            Func<int, Task<int>> taskSomeValue = null;

            await optionTask
                .Awaiting(x => x.MatchAsync(some))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(taskSome))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(some, () => { }))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(taskSome, () => Task.CompletedTask))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(someValue, 0))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(taskSomeValue, 0))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(someValue, () => 0))
                .ShouldThrowAsync<ArgumentNullException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(taskSomeValue, () => Task.FromResult(0)))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, 1, 1, 0)]
        [DataRow(1, 1, 0, 0)]
        [DataRow(null, 1, 1, 1)]
        [DataRow(1, 1, 0, 1)]
        [DataRow(null, 1, 0, 2)]
        [DataRow(1, 1, 2, 2)]
        [DataRow(null, 1, 0, 3)]
        [DataRow(1, 1, 2, 3)]
        [DataRow(null, 1, 1, 4)]
        [DataRow(1, 1, 2, 4)]
        [DataRow(null, 1, 1, 5)]
        [DataRow(1, 1, 2, 5)]
        [DataRow(null, 1, 1, 6)]
        [DataRow(1, 1, 2, 6)]
        [DataRow(null, 1, 1, 7)]
        [DataRow(1, 1, 2, 7)]
        [DataRow(null, 1, 1, 8)]
        [DataRow(1, 1, 2, 8)]
        [DataRow(null, 1, 1, 9)]
        [DataRow(1, 1, 2, 9)]
        public async Task MatchAsync(int? source, int value, int expectedResult, int overload)
        {
            var result = 0;
            var optionTask = source.ToOptionAsync();

            switch (overload)
            {
                case 1:
                    await optionTask.MatchAsync(() =>
                    {
                        result = value;
                        return Task.CompletedTask;
                    });
                    break;
                case 2:
                    await optionTask.MatchAsync(x => { result = x + value; });
                    break;
                case 3:
                    await optionTask.MatchAsync(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    });
                    break;
                case 4:
                    await optionTask.MatchAsync(x => { result = x + value; }, () => { result = value; });
                    break;
                case 5:
                    await optionTask.MatchAsync(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    }, () =>
                    {
                        result = value;
                        return Task.CompletedTask;
                    });
                    break;
                case 6:
                    result = await optionTask.MatchAsync(x => x + value, value);
                    break;
                case 7:
                    result = await optionTask.MatchAsync(x => Task.FromResult(x + value), value);
                    break;
                case 8:
                    result = await optionTask.MatchAsync(x => x + value, () => value);
                    break;
                case 9:
                    result = await optionTask.MatchAsync(x => Task.FromResult(x + value), () => Task.FromResult(value));
                    break;
                default:
                    await optionTask.MatchAsync(() => { result = value; });
                    break;
            }
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task MatchAsyncCanceled()
        {
            var optionTask = OptionTask.None<int>();
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await optionTask
                .Awaiting(x => x.MatchAsync(() => { }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(() => Task.CompletedTask, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => { }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => { }, () => { }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => Task.CompletedTask, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => 0, 0, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), 0, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => 0, () => 0, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await optionTask
                .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => Task.FromResult(0), cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
