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
    public void SourceNullThrowsException()
    {
        Task<int> source = null;

        source
            .Awaiting(x => x.Then(() => { }))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(() => Task.CompletedTask))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(() => 0))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(() => Task.FromResult(0)))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(x => { x++; }))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(_ => Task.CompletedTask))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(x => x++))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(x => Task.FromResult(++x)))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ActionNullThrowsException()
    {
        var source = Task.FromResult(0);
        Action action = null;
        Action<int> genericAction = null;

        source
            .Awaiting(x => x.Then(action))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(genericAction))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void SelectorNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<Task> taskSelector = null;
        Func<int> selector = null;
        Func<Task<int>> genericTaskSelector = null;
        Func<int, Task> taskResultSelector = null;
        Func<int, int> resultSelector = null;
        Func<int, Task<int>> genericTaskResultSelector = null;

        source
            .Awaiting(x => x.Then(taskSelector))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(selector))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(genericTaskSelector))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(taskResultSelector))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(resultSelector))
            .ShouldThrow<ArgumentNullException>();
        source
            .Awaiting(x => x.Then(genericTaskResultSelector))
            .ShouldThrow<ArgumentNullException>();
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
                    .Then(x => { result += value; });
                break;
            case 5:
                await Task
                    .FromResult(result)
                    .Then(x =>
                    {
                        result += value;
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
            .Awaiting(x => x.Then(x => x, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task
            .FromResult(0)
            .Awaiting(x => x.Then(x => Task.FromResult(x), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
