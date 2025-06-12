using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskCatchWhenTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<int> source = null;

        await source
            .Awaiting(x => x.CatchWhen(() => false, () => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(() => false, () => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen<Exception>(_ => false, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen<Exception>(_ => false, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(() => false, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(() => false, () => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen<int, Exception>(_ => false, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen<int, Exception>(_ => false, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ConditionNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<bool> condition = null;

        await source
            .Awaiting(x => x.CatchWhen(condition, () => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(condition, () => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(condition, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(condition, () => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<Exception, bool> predicate = null;

        await source
            .Awaiting(x => x.CatchWhen(predicate, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(predicate, _ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(predicate, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(predicate, _ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ActionNullThrowsException()
    {
        var source = Task.FromResult(0);
        Action action = null;
        Action<Exception> exceptionAction = null;

        await source
            .Awaiting(x => x.CatchWhen(() => false, action))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(_ => false, exceptionAction))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<Task> taskSelector = null;
        Func<Exception, Task> taskExceptionSelector = null;
        Func<int> selector = null;
        Func<Task<int>> genericTaskSelector = null;
        Func<Exception, int> exceptionSelector = null;
        Func<Exception, Task<int>> genericTaskExceptionSelector = null;

        await source
            .Awaiting(x => x.CatchWhen(() => false, taskSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(_ => false, taskExceptionSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(() => false, selector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(() => false, genericTaskSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(_ => false, exceptionSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CatchWhen(_ => false, genericTaskExceptionSelector))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorReturningNullThrowsException()
    {
        var source = Task.FromException<int>(new());

        await source
            .Awaiting(x => x.CatchWhen(() => true, () => default(Task)))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.CatchWhen<Exception>(_ => true, _ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.CatchWhen(() => true, () => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.CatchWhen<int, Exception>(_ => true, _ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 0, false, 0)]
    [TestCase(1, 1, true, 1)]
    [TestCase(1, 0, false, 1)]
    [TestCase(1, 1, true, 2)]
    [TestCase(1, 0, false, 2)]
    [TestCase(1, 1, true, 3)]
    [TestCase(1, 0, false, 3)]
    [TestCase(1, 1, true, 4)]
    [TestCase(1, 0, false, 4)]
    [TestCase(1, 1, true, 5)]
    [TestCase(1, 0, false, 5)]
    [TestCase(1, 1, true, 6)]
    [TestCase(1, 0, false, 6)]
    [TestCase(1, 1, true, 7)]
    [TestCase(1, 0, false, 7)]
    public async Task CatchWhen(int value, int expectedResult, bool isFailed, int overload)
    {
        var result = 0;

        switch (overload)
        {
            case 1:
                await Task
                    .Run(() => isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                    .CatchWhen(() => true, () =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 2:
                await Task
                    .Run(() => isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                    .CatchWhen<Exception>(_ => true, _ => { result += value; });
                break;
            case 3:
                await Task
                    .Run(() => isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                    .CatchWhen<Exception>(_ => true, _ =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 4:
                result = await Task
                    .Run(() => isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                    .CatchWhen(() => true, () => result + value);
                break;
            case 5:
                result = await Task
                    .Run(() => isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                    .CatchWhen(() => true, () => Task.FromResult(result + value));
                break;
            case 6:
                result = await Task
                    .Run(() => isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                    .CatchWhen<int, Exception>(_ => true, _ => result + value);
                break;
            case 7:
                result = await Task
                    .Run(() => isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                    .CatchWhen<int, Exception>(_ => true, _ => Task.FromResult(result + value));
                break;
            default:
                await Task
                    .Run(() => isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                    .CatchWhen(() => true, () => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }

    #endregion
}
