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
    [TestCase(1, 2, 3, 0)]
    [TestCase(1, 2, 3, 1)]
    [TestCase(1, 2, 3, 2)]
    [TestCase(1, 2, 3, 3)]
    [TestCase(1, 2, 3, 4)]
    [TestCase(1, 2, 3, 5)]
    [TestCase(1, 2, 3, 6)]
    [TestCase(1, 2, 3, 7)]
    public async Task CatchWhen(int source, int value, int expectedResult, int overload)
    {
        var result = source;

        switch (overload)
        {
            case 1:
                await Task
                    .FromException(new())
                    .CatchWhen(() => true, () =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 2:
                await Task
                    .FromException(new())
                    .CatchWhen<Exception>(_ => true, _ => { result += value; });
                break;
            case 3:
                await Task
                    .FromException(new())
                    .CatchWhen<Exception>(_ => true, _ =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 4:
                result = await Task
                    .FromException<int>(new())
                    .CatchWhen(() => true, () => result + value);
                break;
            case 5:
                result = await Task
                    .FromException<int>(new())
                    .CatchWhen(() => true, () => Task.FromResult(result + value));
                break;
            case 6:
                result = await Task
                    .FromException<int>(new())
                    .CatchWhen<int, Exception>(_ => true, _ => result + value);
                break;
            case 7:
                result = await Task
                    .FromException<int>(new())
                    .CatchWhen<int, Exception>(_ => true, _ => Task.FromResult(result + value));
                break;
            default:
                await Task
                    .FromException(new())
                    .CatchWhen(() => true, () => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }

    #endregion
}
