using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionMatchAsyncTest
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
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
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
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
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
    public async Task NoneReturningNullThrowsException()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();

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
        await optionTask
            .Awaiting(x => x.MatchAsync(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => { }, () => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, () => default(Task)))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => 0, () => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), () => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    public async Task SomeReturningNullThrowsException()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);

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
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => default, () => { }))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => default(Task), () => Task.CompletedTask))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), () => 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), () => Task.FromResult(0)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, 1, 1, 0)]
    [TestCase(null, 1, 0, 1)]
    [TestCase(null, 1, 1, 2)]
    [TestCase(null, 1, 1, 3)]
    [TestCase(null, 1, 1, 4)]
    [TestCase(null, 1, 1, 5)]
    [TestCase(null, 1, 1, 6)]
    [TestCase(null, 1, 1, 7)]
    [TestCase(null, 1, 1, 8)]
    [TestCase(null, 1, 1, 9)]
    [TestCase(null, 1, 1, 10)]
    [TestCase(null, 1, 0, 11)]
    [TestCase(null, 1, 0, 12)]
    [TestCase(null, 1, 1, 13)]
    [TestCase(null, 1, 1, 14)]
    [TestCase(null, 1, 1, 15)]
    [TestCase(null, 1, 1, 16)]
    [TestCase(null, 1, 1, 17)]
    [TestCase(null, 1, 1, 18)]
    [TestCase(null, 1, 1, 19)]
    [TestCase(null, 1, 1, 20)]
    [TestCase(null, 1, 1, 21)]
    [TestCase(null, 1, 1, 22)]
    [TestCase(1, 1, 0, 0)]
    [TestCase(1, 1, 2, 1)]
    [TestCase(1, 1, 2, 2)]
    [TestCase(1, 1, 2, 3)]
    [TestCase(1, 1, 2, 4)]
    [TestCase(1, 1, 2, 5)]
    [TestCase(1, 1, 2, 6)]
    [TestCase(1, 1, 2, 7)]
    [TestCase(1, 1, 2, 8)]
    [TestCase(1, 1, 0, 9)]
    [TestCase(1, 1, 0, 10)]
    [TestCase(1, 1, 2, 11)]
    [TestCase(1, 1, 2, 12)]
    [TestCase(1, 1, 2, 13)]
    [TestCase(1, 1, 2, 14)]
    [TestCase(1, 1, 2, 15)]
    [TestCase(1, 1, 2, 16)]
    [TestCase(1, 1, 2, 17)]
    [TestCase(1, 1, 2, 18)]
    [TestCase(1, 1, 2, 19)]
    [TestCase(1, 1, 2, 20)]
    [TestCase(1, 1, 2, 21)]
    [TestCase(1, 1, 2, 22)]
    public async Task MatchAsync(int? source, int value, int expectedResult, int overload)
    {
        var result = 0;

        switch (overload)
        {
            case 1:
                await source
                    .ToOption()
                    .MatchAsync(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    });
                break;
            case 2:
                await source
                    .ToOption()
                    .MatchAsync(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    }, () =>
                    {
                        result = value;
                    });
                break;
            case 3:
                await source
                    .ToOption()
                    .MatchAsync(x =>
                    {
                        result = x + value;
                    }, () =>
                    {
                        result = value;
                        return Task.CompletedTask;
                    });
                break;
            case 4:
                await source
                    .ToOption()
                    .MatchAsync(x => 
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
                result = await source
                    .ToOption()
                    .MatchAsync(x => Task.FromResult(x + value), value);
                break;
            case 6:
                result = await source
                    .ToOption()
                    .MatchAsync(x => Task.FromResult(x + value), () => value);
                break;
            case 7:
                result = await source
                    .ToOption()
                    .MatchAsync(x => x + value, () => Task.FromResult(value));
                break;
            case 8:
                result = await source
                    .ToOption()
                    .MatchAsync(x => Task.FromResult(x + value), () => Task.FromResult(value));
                break;
            case 9:
                await source
                    .ToOptionAsync()
                    .MatchAsync(() => { result = value; });
                break;
            case 10:
                await source
                    .ToOptionAsync()
                    .MatchAsync(() =>
                    {
                        result = value;
                        return Task.CompletedTask;
                    });
                break;
            case 11:
                await source
                    .ToOptionAsync()
                    .MatchAsync(x => { result = x + value; });
                break;
            case 12:
                await source
                    .ToOptionAsync()
                    .MatchAsync(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    });
                break;
            case 13:
                await source
                    .ToOptionAsync()
                    .MatchAsync(x => { result = x + value; }, () => { result = value; });
                break;
            case 14:
                await source
                    .ToOptionAsync()
                    .MatchAsync(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    }, () => { result = value; });
                break;
            case 15:
                await source
                    .ToOptionAsync()
                    .MatchAsync(x => { result = x + value; }, () =>
                    {
                        result = value;
                        return Task.CompletedTask;
                    });
                break;
            case 16:
                await source
                    .ToOptionAsync()
                    .MatchAsync(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    }, () =>
                    {
                        result = value;
                        return Task.CompletedTask;
                    });
                break;
            case 17:
                result = await source
                    .ToOptionAsync()
                    .MatchAsync(x => x + value, value);
                break;
            case 18:
                result = await source
                    .ToOptionAsync()
                    .MatchAsync(x => Task.FromResult(x + value), value);
                break;
            case 19:
                result = await source
                    .ToOptionAsync()
                    .MatchAsync(x => x + value, () => value);
                break;
            case 20:
                result = await source
                    .ToOptionAsync()
                    .MatchAsync(x => Task.FromResult(x + value), () => value);
                break;
            case 21:
                result = await source
                    .ToOptionAsync()
                    .MatchAsync(x => x + value, () => Task.FromResult(value));
                break;
            case 22:
                result = await source
                    .ToOptionAsync()
                    .MatchAsync(x => Task.FromResult(x + value), () => Task.FromResult(value));
                break;
            default:
                await source
                    .ToOption()
                    .MatchAsync(() =>
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
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
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
public sealed class ResultMatchAsyncTest
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
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
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
        await result2
            .Awaiting(x => x.MatchAsync(taskOk, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MatchAsync(ok, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MatchAsync(taskOk, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MatchAsync(taskOkValue, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MatchAsync(okValue, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
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
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, Exception>(new());
        var result2Task = ResultTask.Error<int, Exception>(new());
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
        await result2
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, error))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => { }, taskError))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, taskError))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), errorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MatchAsync(y => y, taskErrorValue))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
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
    public async Task OkReturningNullThrowsException()
    {
        var result = Result.Ok(0);
        var resultTask = ResultTask.Ok(0);
        var result2 = Result.Ok<int, int>(0);
        var result2Task = ResultTask.Ok<int, int>(0);

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
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => default, _ => { }))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => default(Task), _ => Task.CompletedTask))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), _ => 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), _ => Task.FromResult(0)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => default, _ => { }))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => default(Task), _ => Task.CompletedTask))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => default, _ => 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), _ => Task.FromResult(0)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => default, _ => { }))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => default(Task), _ => Task.CompletedTask))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), _ => 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => default(Task<int>), _ => Task.FromResult(0)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    public async Task ErrorReturningNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);

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
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => { }, _ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => default(Task)))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => 0, _ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => { }, _ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => default(Task)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => 0, _ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => { }, _ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => default(Task)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => 0, _ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 1, 2, 0)]
    [TestCase(1, 1, 2, 1)]
    [TestCase(1, 1, 2, 2)]
    [TestCase(1, 1, 2, 3)]
    [TestCase(1, 1, 2, 4)]
    [TestCase(1, 1, 2, 5)]
    [TestCase(1, 1, 2, 6)]
    [TestCase(1, 1, 2, 7)]
    [TestCase(1, 1, 2, 8)]
    [TestCase(1, 1, 2, 9)]
    [TestCase(1, 1, 2, 10)]
    [TestCase(1, 1, 2, 11)]
    [TestCase(1, 1, 2, 12)]
    [TestCase(1, 1, 2, 13)]
    [TestCase(1, 1, 2, 14)]
    [TestCase(1, 1, 2, 15)]
    [TestCase(1, 1, 2, 16)]
    [TestCase(1, 1, 2, 17)]
    [TestCase(1, 1, 2, 18)]
    [TestCase(1, 1, 2, 19)]
    [TestCase(1, 1, 2, 20)]
    [TestCase(1, 1, 2, 21)]
    [TestCase(1, 1, 2, 22)]
    [TestCase(1, 1, 2, 23)]
    [TestCase(1, 1, 2, 24)]
    [TestCase(1, 1, 2, 25)]
    [TestCase(1, 1, 2, 26)]
    [TestCase(1, 1, 2, 27)]
    [TestCase(null, 0, 0, 0)]
    [TestCase(null, 0, 0, 1)]
    [TestCase(null, 0, 0, 2)]
    [TestCase(null, 0, 0, 3)]
    [TestCase(null, 0, 0, 4)]
    [TestCase(null, 0, 0, 5)]
    [TestCase(null, 0, 0, 6)]
    [TestCase(null, 0, 0, 7)]
    [TestCase(null, 0, 0, 8)]
    [TestCase(null, 0, 0, 9)]
    [TestCase(null, 0, 0, 10)]
    [TestCase(null, 0, 0, 11)]
    [TestCase(null, 0, 0, 12)]
    [TestCase(null, 0, 0, 13)]
    [TestCase(null, 0, 0, 14)]
    [TestCase(null, 0, 0, 15)]
    [TestCase(null, 0, 0, 16)]
    [TestCase(null, 0, 0, 17)]
    [TestCase(null, 0, 0, 18)]
    [TestCase(null, 0, 0, 19)]
    [TestCase(null, 0, 0, 20)]
    [TestCase(null, 0, 0, 21)]
    [TestCase(null, 0, 0, 22)]
    [TestCase(null, 0, 0, 23)]
    [TestCase(null, 0, 0, 24)]
    [TestCase(null, 0, 0, 25)]
    [TestCase(null, 0, 0, 26)]
    [TestCase(null, 0, 0, 27)]
    public async Task MatchAsync(int? source, int value, int expectedResult, int overload)
    {
        var currentResult = 0;

        switch (overload)
        {
            case 1:
                await source
                    .Match(Result.Ok, () => Result.Error<int>(new HResultException(value)))
                    .MatchAsync(x => { currentResult = x + value; }, x =>
                    {
                        currentResult = x.HResult;
                        return Task.CompletedTask;
                    });
                break;
            case 2:
                await source
                    .Match(Result.Ok, () => Result.Error<int>(new HResultException(value)))
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
            case 3:
                currentResult = await source
                    .Match(Result.Ok, () => Result.Error<int>(new HResultException(value)))
                    .MatchAsync(x => Task.FromResult(x + value), x => x.HResult);
                break;
            case 4:
                currentResult = await source
                    .Match(Result.Ok, () => Result.Error<int>(new HResultException(value)))
                    .MatchAsync(x => x + value, x => Task.FromResult(x.HResult));
                break;
            case 5:
                currentResult = await source
                    .Match(Result.Ok, () => Result.Error<int>(new HResultException(value)))
                    .MatchAsync(x => Task.FromResult(x + value), x => Task.FromResult(x.HResult));
                break;
            case 6:
                await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => { currentResult = x + value; }, x => { currentResult = x.HResult; });
                break;
            case 7:
                await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x =>
                    {
                        currentResult = x + value;
                        return Task.CompletedTask;
                    }, x => { currentResult = x.HResult; });
                break;
            case 8:
                await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => { currentResult = x + value; }, x =>
                    {
                        currentResult = x.HResult;
                        return Task.CompletedTask;
                    });
                break;
            case 9:
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
            case 10:
                currentResult = await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => x + value, x => x.HResult);
                break;
            case 11:
                currentResult = await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => Task.FromResult(x + value), x => x.HResult);
                break;
            case 12:
                currentResult = await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => x + value, x => Task.FromResult(x.HResult));
                break;
            case 13:
                currentResult = await source
                    .Match(ResultTask.Ok, () => ResultTask.Error<int>(new HResultException(value)))
                    .MatchAsync(x => Task.FromResult(x + value), x => Task.FromResult(x.HResult));
                break;
            case 14:
                await source
                    .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                    .MatchAsync(x =>
                    {
                        currentResult = x + value;
                        return Task.CompletedTask;
                    }, x => currentResult = x);
                break;
            case 15:
                await source
                    .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                    .MatchAsync(x => { currentResult = x + value; }, x =>
                    {
                        currentResult = value;
                        return Task.CompletedTask;
                    });
                break;
            case 16:
                await source
                    .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
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
            case 17:
                currentResult = await source
                    .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                    .MatchAsync(x => Task.FromResult(x + value), x => x);
                break;
            case 18:
                currentResult = await source
                    .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                    .MatchAsync(x => x + value, Task.FromResult);
                break;
            case 19:
                currentResult = await source
                    .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                    .MatchAsync(x => Task.FromResult(x + value), Task.FromResult);
                break;
            case 20:
                await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => { currentResult = x + value; }, x => { currentResult = x; });
                break;
            case 21:
                await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x =>
                    {
                        currentResult = x + value;
                        return Task.CompletedTask;
                    }, x => { currentResult = x; });
                break;
            case 22:
                await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => { currentResult = x + value; }, x =>
                    {
                        currentResult = x;
                        return Task.CompletedTask;
                    });
                break;
            case 23:
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
            case 24:
                currentResult = await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => x + value, x => x);
                break;
            case 25:
                currentResult = await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => Task.FromResult(x + value), x => x);
                break;
            case 26:
                currentResult = await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => x + value, Task.FromResult);
                break;
            case 27:
                currentResult = await source
                    .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                    .MatchAsync(x => Task.FromResult(x + value), Task.FromResult);
                break;
            default:
                await source
                    .Match(Result.Ok, () => Result.Error<int>(new HResultException(value)))
                    .MatchAsync(x =>
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
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
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
        await result2
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => { }, _ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => Task.CompletedTask, _ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => Task.FromResult(0), _ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.MatchAsync(_ => 0, _ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
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
