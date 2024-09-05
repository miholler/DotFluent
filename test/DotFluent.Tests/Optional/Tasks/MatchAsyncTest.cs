using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionMatchAsyncTest
{
    #region Methods

    [Test]
    public async Task NoneNullThrowsException()
    {
        var option = await OptionTask.None<int>();
        Action none = null;
        Func<int> noneValue = null;
        Func<Task> taskNone = null;
        Func<Task<int>> taskNoneValue = null;

        await option
            .Awaiting(x => x.MatchAsync(taskNone))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, none))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => { }, taskNone))
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
        var option = await OptionTask.None<int>();
        Action<int> some = null;
        Func<int, int> someValue = null;
        Func<int, Task> taskSome = null;
        Func<int, Task<int>> taskSomeValue = null;

        await option
            .Awaiting(x => x.MatchAsync(taskSome))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(taskSome, () => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await option
            .Awaiting(x => x.MatchAsync(some, () => Task.CompletedTask))
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
            .Awaiting(x => x.MatchAsync(_ => { }, () => default))
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
            .Awaiting(x => x.MatchAsync(_ => default, () => { }))
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
    [TestCase(1, 1, 2, 7)]
    [TestCase(null, 1, 1, 7)]
    [TestCase(1, 1, 2, 8)]
    [TestCase(null, 1, 1, 8)]
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
                });
                break;
            case 3:
                await option.MatchAsync(x =>
                {
                    result = x + value;
                }, () =>
                {
                    result = value;
                    return Task.CompletedTask;
                });
                break;
            case 4:
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
            case 5:
                result = await option.MatchAsync(x => Task.FromResult(x + value), value);
                break;
            case 6:
                result = await option.MatchAsync(x => Task.FromResult(x + value), () => value);
                break;
            case 7:
                result = await option.MatchAsync(x => x + value, () => Task.FromResult(value));
                break;
            case 8:
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
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await option
            .Awaiting(x => x.MatchAsync(_ => { }, () => Task.CompletedTask, cts.Token))
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

[TestFixture]
public sealed class ResultMatchAsyncTest
{
    #region Methods

    [Test]
    public async Task OkNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());
        Action<int> ok = null;
        Func<int, int> okValue = null;
        Func<int, Task> taskOk = null;
        Func<int, Task<int>> taskOkValue = null;

        await result
            .Awaiting(x => x.MatchAsync(taskOk, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(ok, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(taskOk, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(taskOkValue, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(okValue, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(taskOkValue, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ErrorNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());
        Action<Exception> error = null;
        Func<Exception, int> errorValue = null;
        Func<Exception, Task> taskError = null;
        Func<Exception, Task<int>> taskErrorValue = null;

        await result
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, error))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => { }, taskError))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, taskError))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), errorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(y => y, taskErrorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), taskErrorValue))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OkReturningNullThrowsException()
    {
        var result = await ResultTask.Ok(0);

        await result
            .Awaiting(x => x.MatchAsync(_ => default, _ => { }))
            .ShouldThrowAsync<InvalidOperationException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => default(Task), _ => Task.CompletedTask))
            .ShouldThrowAsync<InvalidOperationException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => default, _ => 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), _ => Task.FromResult(0)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    public async Task ErrorReturningNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());

        await result
            .Awaiting(x => x.MatchAsync(_ => { }, _ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => default(Task)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => 0, _ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 1, 2, 0)]
    [TestCase(null, 0, 0, 0)]
    [TestCase(1, 1, 2, 1)]
    [TestCase(null, 0, 0, 1)]
    [TestCase(1, 1, 2, 2)]
    [TestCase(null, 0, 0, 2)]
    [TestCase(1, 1, 2, 3)]
    [TestCase(null, 0, 0, 3)]
    [TestCase(1, 1, 2, 4)]
    [TestCase(null, 0, 0, 4)]
    [TestCase(1, 1, 2, 5)]
    [TestCase(null, 0, 0, 5)]
    public async Task MatchAsync(int? source, int value, int expectedResult, int overload)
    {
        var currentResult = 0;
        var result = await source.Match(ResultTask.Ok, () => ResultTask.Error<int>(new() { HResult = value }));

        switch (overload)
        {
            case 1:
                await result.MatchAsync(x => { currentResult = x + value; }, x =>
                {
                    currentResult = x.HResult;
                    return Task.CompletedTask;
                });
                break;
            case 2:
                await result.MatchAsync(x =>
                {
                    currentResult = x + value;
                    return Task.CompletedTask;
                }, x =>
                {
                    currentResult = x.HResult;
                    return Task.CompletedTask;
                });
                break;
            case 3:
                currentResult = await result.MatchAsync(x => Task.FromResult(x + value), x => x.HResult);
                break;
            case 4:
                currentResult = await result.MatchAsync(x => x + value, x => Task.FromResult(x.HResult));
                break;
            case 5:
                currentResult = await result.MatchAsync(x => Task.FromResult(x + value), x => Task.FromResult(x.HResult));
                break;
            default:
                await result.MatchAsync(x =>
                {
                    currentResult = x + value;
                    return Task.CompletedTask;
                }, x => currentResult = x.HResult);
                break;
        }
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task MatchAsyncCanceled()
    {
        var result = await ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => { }, _ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => 0, _ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
