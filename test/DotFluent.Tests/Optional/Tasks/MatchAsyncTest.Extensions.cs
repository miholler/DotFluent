using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class MatchAsyncExtensionsTest
{
    #region Methods

    [Test]
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
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => 0, () => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
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
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), noneValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => 0, taskNoneValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), taskNoneValue))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
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
            .Awaiting(x => x.MatchAsync(taskSomeValue, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(someValue, () => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(taskSomeValue, () => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, 1, 0)]
    [TestCase(1, 1, 0, 0)]
    [TestCase(null, 1, 1, 1)]
    [TestCase(1, 1, 0, 1)]
    [TestCase(null, 1, 0, 2)]
    [TestCase(1, 1, 2, 2)]
    [TestCase(null, 1, 0, 3)]
    [TestCase(1, 1, 2, 3)]
    [TestCase(null, 1, 1, 4)]
    [TestCase(1, 1, 2, 4)]
    [TestCase(null, 1, 1, 5)]
    [TestCase(1, 1, 2, 5)]
    [TestCase(null, 1, 1, 6)]
    [TestCase(1, 1, 2, 6)]
    [TestCase(null, 1, 1, 7)]
    [TestCase(1, 1, 2, 7)]
    [TestCase(null, 1, 1, 8)]
    [TestCase(1, 1, 2, 8)]
    [TestCase(null, 1, 1, 9)]
    [TestCase(1, 1, 2, 9)]
    [TestCase(null, 1, 1, 10)]
    [TestCase(1, 1, 2, 10)]
    [TestCase(null, 1, 1, 11)]
    [TestCase(1, 1, 2, 11)]
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
                result = await optionTask.MatchAsync(x => Task.FromResult(x + value), () => value);
                break;
            case 10:
                result = await optionTask.MatchAsync(x => x + value, () => Task.FromResult(value));
                break;
            case 11:
                result = await optionTask.MatchAsync(x => Task.FromResult(x + value), () => Task.FromResult(value));
                break;
            default:
                await optionTask.MatchAsync(() => { result = value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }

    [Test]
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
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => 0, () => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
