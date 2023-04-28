using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class MatchAsyncTest
{
    #region Methods

    [Test]
    public async Task NoneNullThrowsException()
    {
        var option = await OptionTask.None<int>();
        Func<int> noneValue = null;
        Func<Task> taskNone = null;
        Func<Task<int>> taskNoneValue = null;

        await option
            .Awaiting(x => x.MatchAsync(taskNone))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, taskNone))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), noneValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => 0, taskNoneValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), taskNoneValue))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SomeNullThrowsException()
    {
        var option = await OptionTask.Some(0);
        Func<int, int> someValue = null;
        Func<int, Task> taskSome = null;
        Func<int, Task<int>> taskSomeValue = null;

        await option
            .Awaiting(x => x.MatchAsync(taskSome))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(taskSome, () => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(taskSomeValue, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(taskSomeValue, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(someValue, () => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(taskSomeValue, () => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task NoneReturningNullThrowsException()
    {
        var option = await OptionTask.None<int>();

        await option
            .Awaiting(x => x.MatchAsync(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => default(Task)))
            .ShouldThrowAsync<InvalidOperationException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => 0, () => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    public async Task SomeReturningNullThrowsException()
    {
        var option = await OptionTask.Some(0);

        await option
            .Awaiting(x => x.MatchAsync(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => default(Task), () => Task.CompletedTask))
            .ShouldThrowAsync<InvalidOperationException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => default, 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => default, () => 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), () => Task.FromResult(0)))
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
    [TestCase(1, 1, 2, 5)]
    [TestCase(null, 1, 1, 5)]
    [TestCase(1, 1, 2, 6)]
    [TestCase(null, 1, 1, 6)]
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
                result = await option.MatchAsync(x => Task.FromResult(x + value), () => value);
                break;
            case 5:
                result = await option.MatchAsync(x => x + value, () => Task.FromResult(value));
                break;
            case 6:
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
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => 0, () => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
