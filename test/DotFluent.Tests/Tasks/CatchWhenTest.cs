using NUnit.Framework;
using Shouldly;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskCatchWhenTest
{
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
        var source = Task.CompletedTask;
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
                await (isFailed
                    ? Task.FromException(new())
                    : Task.CompletedTask)
                    .CatchWhen(() => true, () =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 2:
                await (isFailed
                    ? Task.FromException(new())
                    : Task.CompletedTask)
                    .CatchWhen<Exception>(_ => true, _ => { result += value; });
                break;
            case 3:
                await (isFailed
                    ? Task.FromException(new())
                    : Task.CompletedTask)
                    .CatchWhen<Exception>(_ => true, _ =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 4:
                result = await (isFailed
                    ? Task.FromException<int>(new())
                    : Task.FromResult(result))
                    .CatchWhen(() => true, () => result + value);
                break;
            case 5:
                result = await (isFailed
                    ? Task.FromException<int>(new())
                    : Task.FromResult(result))
                    .CatchWhen(() => true, () => Task.FromResult(result + value));
                break;
            case 6:
                result = await (isFailed
                    ? Task.FromException<int>(new())
                    : Task.FromResult(result))
                    .CatchWhen<int, Exception>(_ => true, _ => result + value);
                break;
            case 7:
                result = await (isFailed
                    ? Task.FromException<int>(new())
                    : Task.FromResult(result))
                    .CatchWhen<int, Exception>(_ => true, _ => Task.FromResult(result + value));
                break;
            default:
                await (isFailed
                    ? Task.FromException(new())
                    : Task.CompletedTask)
                    .CatchWhen(() => true, () => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }
}

[TestFixture]
public sealed class ValueTaskCatchWhenTest
{
    [Test]
    public async Task ConditionNullThrowsException()
    {
        Func<bool> condition = null;

        await condition
            .Awaiting(x => ValueTask.CompletedTask.CatchWhen(x, () => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await condition
            .Awaiting(x => ValueTask.CompletedTask.CatchWhen(x, () => ValueTask.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await condition
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(x, () => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await condition
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(x, () => ValueTask.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await condition
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(x, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await condition
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(x, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        Func<Exception, bool> predicate = null;

        await predicate
            .Awaiting(x => ValueTask.CompletedTask.CatchWhen(x, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await predicate
            .Awaiting(x => ValueTask.CompletedTask.CatchWhen(x, _ => ValueTask.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await predicate
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(x, _ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await predicate
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(x, _ => ValueTask.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await predicate
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(x, _ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await predicate
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(x, _ => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ActionNullThrowsException()
    {
        Action action = null;
        Action<Exception> exceptionAction = null;

        await action
            .Awaiting(x => ValueTask.CompletedTask.CatchWhen(() => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await exceptionAction
            .Awaiting(x => ValueTask.CompletedTask.CatchWhen(_ => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await action
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(() => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await exceptionAction
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(_ => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorNullThrowsException()
    {
        Func<ValueTask> taskSelector = null;
        Func<Exception, ValueTask> taskExceptionSelector = null;
        Func<int> selector = null;
        Func<ValueTask<int>> genericTaskSelector = null;
        Func<Exception, int> exceptionSelector = null;
        Func<Exception, ValueTask<int>> genericTaskExceptionSelector = null;

        await taskSelector
            .Awaiting(x => ValueTask.CompletedTask.CatchWhen(() => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await taskExceptionSelector
            .Awaiting(x => ValueTask.CompletedTask.CatchWhen(_ => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await taskSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(() => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await selector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(() => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericTaskSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(() => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await taskExceptionSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(_ => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await exceptionSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(_ => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericTaskExceptionSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .CatchWhen(_ => false, x))
            .ShouldThrowAsync<ArgumentNullException>();
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
    [TestCase(1, 1, true, 8)]
    [TestCase(1, 0, false, 8)]
    [TestCase(1, 1, true, 9)]
    [TestCase(1, 0, false, 9)]
    [TestCase(1, 1, true, 10)]
    [TestCase(1, 0, false, 10)]
    [TestCase(1, 1, true, 11)]
    [TestCase(1, 0, false, 11)]
    public async Task CatchWhen(int value, int expectedResult, bool isFailed, int overload)
    {
        var result = 0;

        switch (overload)
        {
            case 1:
                await (isFailed
                    ? ValueTask.FromException(new())
                    : ValueTask.CompletedTask)
                    .CatchWhen(() => true, () => ValueTask.FromException(new()))
                    .CatchWhen(() => true, () =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 2:
                await (isFailed
                    ? ValueTask.FromException(new())
                    : ValueTask.CompletedTask)
                    .CatchWhen<Exception>(_ => true, _ => { result += value; });
                break;
            case 3:
                await (isFailed
                    ? ValueTask.FromException(new())
                    : ValueTask.CompletedTask)
                    .CatchWhen<Exception>(_ => true, ValueTask.FromException)
                    .CatchWhen<Exception>(_ => true, _ =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 4:
                await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .CatchWhen(() => true, () => { result += value; });
                break;
            case 5:
                await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .CatchWhen(() => true, () => ValueTask.FromException(new()))
                    .CatchWhen(() => true, () =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 6:
                result = await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .CatchWhen(() => true, () => result + value);
                break;
            case 7:
                result = await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .CatchWhen(() => true, () => ValueTask.FromException<int>(new()))
                    .CatchWhen(() => true, () => ValueTask.FromResult(result + value));
                break;
            case 8:
                await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .CatchWhen<int, Exception>(_ => true, _ => { result += value; });
                break;
            case 9:
                await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .CatchWhen<int, Exception>(_ => true, ValueTask.FromException)
                    .CatchWhen<Exception>(_ => true, _ =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 10:
                result = await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .CatchWhen<int, Exception>(_ => true, _ => result + value);
                break;
            case 11:
                result = await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .CatchWhen<int, Exception>(_ => true, ValueTask.FromException<int>)
                    .CatchWhen<int, Exception>(_ => true, _ => ValueTask.FromResult(result + value));
                break;
            default:
                await (isFailed
                    ? ValueTask.FromException(new())
                    : ValueTask.CompletedTask)
                    .CatchWhen(() => true, () => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }
}
