using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionMatchAsyncExtensionsTest
{
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
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => { }, () => Task.CompletedTask))
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
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, none))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => { }, taskNone))
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
            .Awaiting(x => x.MatchAsync(taskSome, () => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(some, () => Task.CompletedTask))
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
    [TestCase(null, 1, 1, 12)]
    [TestCase(1, 1, 2, 12)]
    [TestCase(null, 1, 1, 13)]
    [TestCase(1, 1, 2, 13)]
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
                });
                break;
            case 6:
                await optionTask.MatchAsync(x =>
                {
                    result = x + value;
                }, () =>
                {
                    result = value;
                    return Task.CompletedTask;
                });
                break;
            case 7:
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
            case 8:
                result = await optionTask.MatchAsync(x => x + value, value);
                break;
            case 9:
                result = await optionTask.MatchAsync(x => Task.FromResult(x + value), value);
                break;
            case 10:
                result = await optionTask.MatchAsync(x => x + value, () => value);
                break;
            case 11:
                result = await optionTask.MatchAsync(x => Task.FromResult(x + value), () => value);
                break;
            case 12:
                result = await optionTask.MatchAsync(x => x + value, () => Task.FromResult(value));
                break;
            case 13:
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
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => { }, () => Task.CompletedTask, cts.Token))
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
}

[TestFixture]
public sealed class ResultMatchAsyncExtensionsTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.MatchAsync(_ => { }, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => { }, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => 0, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => 0, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => { }, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => { }, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => 0, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => 0, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OkNullThrowsException()
    {
        var resultTask = ResultTask.Error<int>(new());
        var result2Task = ResultTask.Error<int, int>(0);
        Action<int> ok = null;
        Func<int, int> okValue = null;
        Func<int, Task> taskOk = null;
        Func<int, Task<int>> taskOkValue = null;

        await resultTask
            .Awaiting(x => x.MatchAsync(ok, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(taskOk, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(ok, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(taskOk, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(okValue, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(taskOkValue, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(okValue, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(taskOkValue, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(ok, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(taskOk, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(ok, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(taskOk, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(okValue, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(taskOkValue, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(okValue, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(taskOkValue, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ErrorNullThrowsException()
    {
        var resultTask = ResultTask.Error<int>(new());
        var result2Task = ResultTask.Error<int, Exception>(new());
        Action<Exception> error = null;
        Func<Exception, int> errorValue = null;
        Func<Exception, Task> taskError = null;
        Func<Exception, Task<int>> taskErrorValue = null;

        await resultTask
            .Awaiting(x => x.MatchAsync(_ => { }, error))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, error))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => { }, taskError))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, taskError))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => 0, errorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), errorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => 0, taskErrorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), taskErrorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => { }, error))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, error))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => { }, taskError))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, taskError))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => 0, errorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), errorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => 0, taskErrorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), taskErrorValue))
            .ShouldThrowAsync<ArgumentNullException>();
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
    [TestCase(1, 1, 2, 6)]
    [TestCase(null, 0, 0, 6)]
    [TestCase(1, 1, 2, 7)]
    [TestCase(null, 0, 0, 7)]
    [TestCase(1, 1, 2, 8)]
    [TestCase(null, 0, 0, 8)]
    [TestCase(1, 1, 2, 9)]
    [TestCase(null, 0, 0, 9)]
    [TestCase(1, 1, 2, 10)]
    [TestCase(null, 0, 0, 10)]
    [TestCase(1, 1, 2, 11)]
    [TestCase(null, 0, 0, 11)]
    [TestCase(1, 1, 2, 12)]
    [TestCase(null, 0, 0, 12)]
    [TestCase(1, 1, 2, 13)]
    [TestCase(null, 0, 0, 13)]
    [TestCase(1, 1, 2, 14)]
    [TestCase(null, 0, 0, 14)]
    [TestCase(1, 1, 2, 15)]
    [TestCase(null, 0, 0, 15)]
    public async Task MatchAsync(int? source, int value, int expectedResult, int overload)
    {
        var currentResult = 0;

        switch (overload)
        {
            case 1:
                await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x =>
                    {
                        currentResult = x + value;
                        return Task.CompletedTask;
                    }, x => { currentResult = x.HResult; });
                break;
            case 2:
                await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => { currentResult = x + value; }, x =>
                    {
                        currentResult = x.HResult;
                        return Task.CompletedTask;
                    });
                break;
            case 3:
                await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x =>
                    {
                        currentResult = x + value;
                        return Task.CompletedTask;
                    }, x =>
                    {
                        currentResult = x.HResult;
                        return Task.CompletedTask;
                    });
                break;
            case 4:
                currentResult = await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => x + value, x => x.HResult);
                break;
            case 5:
                currentResult = await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => Task.FromResult(x + value), x => x.HResult);
                break;
            case 6:
                currentResult = await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => x + value, x => Task.FromResult(x.HResult));
                break;
            case 7:
                currentResult = await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => Task.FromResult(x + value), x => Task.FromResult(x.HResult));
                break;
            case 8:
                await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => { currentResult = x + value; }, x => { currentResult = x; });
                break;
            case 9:
                await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x =>
                    {
                        currentResult = x + value;
                        return Task.CompletedTask;
                    }, x => { currentResult = x; });
                break;
            case 10:
                await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => { currentResult = x + value; }, x =>
                    {
                        currentResult = x;
                        return Task.CompletedTask;
                    });
                break;
            case 11:
                await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x =>
                    {
                        currentResult = x + value;
                        return Task.CompletedTask;
                    }, x =>
                    {
                        currentResult = x;
                        return Task.CompletedTask;
                    });
                break;
            case 12:
                currentResult = await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => x + value, x => x);
                break;
            case 13:
                currentResult = await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => Task.FromResult(x + value), x => x);
                break;
            case 14:
                currentResult = await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => x + value, Task.FromResult);
                break;
            case 15:
                currentResult = await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => Task.FromResult(x + value), Task.FromResult);
                break;
            default:
                await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => { currentResult = x + value; }, x => { currentResult = x.HResult; });
                break;
        }
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task MatchAsyncCanceled()
    {
        var resultTask = ResultTask.Error<int>(new());
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await resultTask
            .Awaiting(x => x.MatchAsync(_ => { }, _ => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => { }, _ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => 0, _ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => 0, _ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => { }, _ => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => { }, _ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => 0, _ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => 0, _ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
