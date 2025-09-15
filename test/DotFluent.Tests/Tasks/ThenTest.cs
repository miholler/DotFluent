using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskThenTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<int> source = null;

        await source
            .Awaiting(x => x.Then(() => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(() => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(y => { y++; }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(_ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(y => y++))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(y => Task.FromResult(++y)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ActionNullThrowsException()
    {
        var source = Task.FromResult(0);
        Action action = null;
        Action<int> genericAction = null;

        await source
            .Awaiting(x => x.Then(action))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(genericAction))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<Task> taskSelector = null;
        Func<int> selector = null;
        Func<Task<int>> genericTaskSelector = null;
        Func<int, Task> taskResultSelector = null;
        Func<int, int> resultSelector = null;
        Func<int, Task<int>> genericTaskResultSelector = null;

        await source
            .Awaiting(x => x.Then(taskSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(selector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(genericTaskSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(taskResultSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(resultSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Then(genericTaskResultSelector))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorReturningNullThrowsException()
    {
        var source = Task.FromResult(0);

        await source
            .Awaiting(x => x.Then(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.Then(() => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.Then(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.Then(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 1, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(1, 1, 2)]
    [TestCase(1, 1, 3)]
    [TestCase(1, 1, 4)]
    [TestCase(1, 1, 5)]
    [TestCase(1, 1, 6)]
    [TestCase(1, 1, 7)]
    public async Task Then(int value, int expectedResult, int overload)
    {
        var result = 0;

        switch (overload)
        {
            case 1:
                await Task.CompletedTask.Then(() =>
                {
                    result += value;
                    return Task.CompletedTask;
                });
                break;
            case 2:
                result = await Task.CompletedTask.Then(() => result + value);
                break;
            case 3:
                result = await Task.CompletedTask.Then(() => Task.FromResult(result + value));
                break;
            case 4:
                await Task
                    .FromResult(result)
                    .Then(x => { result = x + value; });
                break;
            case 5:
                await Task
                    .FromResult(result)
                    .Then(x =>
                    {
                        result = x + value;
                        return Task.CompletedTask;
                    });
                break;
            case 6:
                result = await Task
                    .FromResult(result)
                    .Then(x => x + value);
                break;
            case 7:
                result = await Task
                    .FromResult(result)
                    .Then(x => Task.FromResult(x + value));
                break;
            default:
                await Task.CompletedTask.Then(() => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ThenCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await Task.CompletedTask
            .Awaiting(x => x.Then(() => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task.CompletedTask
            .Awaiting(x => x.Then(() => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task.CompletedTask
            .Awaiting(x => x.Then(() => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task.CompletedTask
            .Awaiting(x => x.Then(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task
            .FromResult(0)
            .Awaiting(x => x.Then(_ => { }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task
            .FromResult(0)
            .Awaiting(x => x.Then(_ => Task.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task
            .FromResult(0)
            .Awaiting(x => x.Then(y => y, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task
            .FromResult(0)
            .Awaiting(x => x.Then(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ValueTaskThenTest
{
    [Test]
    public async Task ActionNullThrowsException()
    {
        Action action = null;
        Action<int> genericAction = null;

        await action
            .Awaiting(x => ValueTask.CompletedTask.Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await action
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericAction
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorNullThrowsException()
    {
        Func<ValueTask> taskSelector = null;
        Func<int> selector = null;
        Func<ValueTask<int>> genericTaskSelector = null;
        Func<int, ValueTask> taskResultSelector = null;
        Func<int, int> resultSelector = null;
        Func<int, ValueTask<int>> genericTaskResultSelector = null;

        await taskSelector
            .Awaiting(x => ValueTask.CompletedTask.Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await selector
            .Awaiting(x => ValueTask.CompletedTask.Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericTaskSelector
            .Awaiting(x => ValueTask.CompletedTask.Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await taskSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await taskResultSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await selector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericTaskSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericTaskResultSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(x))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(1, 1, 2)]
    [TestCase(1, 1, 3)]
    [TestCase(1, 1, 4)]
    [TestCase(1, 1, 5)]
    [TestCase(1, 1, 6)]
    [TestCase(1, 1, 7)]
    [TestCase(1, 1, 8)]
    [TestCase(1, 1, 9)]
    [TestCase(1, 1, 10)]
    [TestCase(1, 1, 11)]
    public async Task Then(int value, int expectedResult, int overload)
    {
        var result = 0;

        switch (overload)
        {
            case 1:
                await ValueTask.CompletedTask.Then(() =>
                {
                    result += value;
                    return ValueTask.CompletedTask;
                });
                break;
            case 2:
                result = await ValueTask.CompletedTask.Then(() => result + value);
                break;
            case 3:
                result = await ValueTask.CompletedTask.Then(() => ValueTask.FromResult(result + value));
                break;
            case 4:
                await ValueTask
                    .FromResult(result)
                    .Then(() => { result += value; });
                break;
            case 5:
                await ValueTask
                    .FromResult(result)
                    .Then(() =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 6:
                await ValueTask
                    .FromResult(result)
                    .Then(x => { result = x + value; });
                break;
            case 7:
                await ValueTask
                    .FromResult(result)
                    .Then(x =>
                    {
                        result = x + value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 8:
                result = await ValueTask
                    .FromResult(result)
                    .Then(() => result + value);
                break;
            case 9:
                result = await ValueTask
                    .FromResult(result)
                    .Then(() => ValueTask.FromResult(result + value));
                break;
            case 10:
                result = await ValueTask
                    .FromResult(result)
                    .Then(x => x + value);
                break;
            case 11:
                result = await ValueTask
                    .FromResult(result)
                    .Then(x => ValueTask.FromResult(x + value));
                break;
            default:
                await ValueTask.CompletedTask.Then(() => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ThenCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await cts.Token
            .Awaiting(x => ValueTask
                .FromCanceled(x)
                .Then(() => { }, CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask.CompletedTask
                .Then(() => ValueTask
                    .FromCanceled(x)
                    .Then(() => ValueTask.FromCanceled(x), CancellationToken.None), CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromCanceled(x)
                .Then(() => 0, CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask.CompletedTask
                .Then(() => ValueTask
                    .FromCanceled(x)
                    .Then(() => ValueTask.FromCanceled<int>(x), CancellationToken.None), CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromCanceled<int>(x)
                .Then(() => { }, CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(() => ValueTask
                    .FromCanceled<int>(x)
                    .Then(() => ValueTask.FromCanceled(x), CancellationToken.None), CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromCanceled<int>(x)
                .Then(_ => { }, CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(_ => ValueTask
                    .FromCanceled<int>(x)
                    .Then(_ => ValueTask.FromCanceled(x), CancellationToken.None), CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromCanceled<int>(x)
                .Then(() => 0, CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(() => ValueTask
                    .FromCanceled<int>(x)
                    .Then(() => ValueTask.FromCanceled<int>(x), CancellationToken.None), CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromCanceled<int>(x)
                .Then(y => y, CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
        await cts.Token
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Then(_ => ValueTask
                    .FromCanceled<int>(x)
                    .Then(_ => ValueTask.FromCanceled<int>(x), CancellationToken.None), CancellationToken.None))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
