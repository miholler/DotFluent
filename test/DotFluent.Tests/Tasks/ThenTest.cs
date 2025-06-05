using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskThenTest
{
    #region Methods

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
    [TestCase(1, 2, 3, 0)]
    [TestCase(1, 2, 3, 1)]
    [TestCase(1, 2, 3, 2)]
    [TestCase(1, 2, 3, 3)]
    [TestCase(1, 2, 3, 4)]
    [TestCase(1, 2, 3, 5)]
    [TestCase(1, 2, 3, 6)]
    [TestCase(1, 2, 3, 7)]
    public async Task Then(int source, int value, int expectedResult, int overload)
    {
        var result = source;

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

    #endregion
}
