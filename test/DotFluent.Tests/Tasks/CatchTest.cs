using NUnit.Framework;
using Shouldly;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskCatchTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<int> source = null;

        await source
            .Awaiting(x => x.Catch(() => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(() => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch<Exception>(_ => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch<Exception>(_ => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch<int, Exception>(_ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch<int, Exception>(_ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ActionNullThrowsException()
    {
        var source = Task.CompletedTask;
        Action action = null;
        Action<Exception> exceptionAction = null;

        await source
            .Awaiting(x => x.Catch(action))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(exceptionAction))
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
            .Awaiting(x => x.Catch(taskSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(taskExceptionSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(selector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(genericTaskSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(exceptionSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Catch(genericTaskExceptionSelector))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorReturningNullThrowsException()
    {
        var source = Task.FromException<int>(new());

        await source
            .Awaiting(x => x.Catch(() => default(Task)))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.Catch<Exception>(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.Catch(() => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.Catch<int, Exception>(_ => default(Task<int>)))
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
    public async Task Catch(int value, int expectedResult, bool isFailed, int overload)
    {
        var result = 0;

        switch (overload)
        {
            case 1:
                await (isFailed
                    ? Task.FromException(new())
                    : Task.CompletedTask)
                    .Catch(() =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 2:
                await (isFailed
                    ? Task.FromException(new())
                    : Task.CompletedTask)
                    .Catch<Exception>(_ => { result += value; });
                break;
            case 3:
                await (isFailed
                    ? Task.FromException(new())
                    : Task.CompletedTask)
                    .Catch<Exception>(_ =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 4:
                result = await (isFailed
                    ? Task.FromException<int>(new())
                    : Task.FromResult(result))
                    .Catch(() => result + value);
                break;
            case 5:
                result = await (isFailed
                    ? Task.FromException<int>(new())
                    : Task.FromResult(result))
                    .Catch(() => Task.FromResult(result + value));
                break;
            case 6:
                result = await (isFailed
                    ? Task.FromException<int>(new())
                    : Task.FromResult(result))
                    .Catch<int, Exception>(_ => result + value);
                break;
            case 7:
                result = await (isFailed
                    ? Task.FromException<int>(new())
                    : Task.FromResult(result))
                    .Catch<int, Exception>(_ => Task.FromResult(result + value));
                break;
            default:
                await (isFailed
                    ? Task.FromException(new())
                    : Task.CompletedTask)
                    .Catch(() => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }
}

[TestFixture]
public sealed class ValueTaskCatchTest
{
    [Test]
    public async Task ActionNullThrowsException()
    {
        Action action = null;
        Action<Exception> exceptionAction = null;

        await action
            .Awaiting(x => ValueTask.CompletedTask.Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await exceptionAction
            .Awaiting(x => ValueTask.CompletedTask.Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await action
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await exceptionAction
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Catch(x))
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
            .Awaiting(x => ValueTask.CompletedTask.Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await taskExceptionSelector
            .Awaiting(x => ValueTask.CompletedTask.Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await taskSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await selector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericTaskSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await taskExceptionSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await exceptionSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Catch(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericTaskExceptionSelector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Catch(x))
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
    public async Task Catch(int value, int expectedResult, bool isFailed, int overload)
    {
        var result = 0;

        switch (overload)
        {
            case 1:
                await (isFailed
                    ? ValueTask.FromException(new())
                    : ValueTask.CompletedTask)
                    .Catch(() =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 2:
                await (isFailed
                    ? ValueTask.FromException(new())
                    : ValueTask.CompletedTask)
                    .Catch<Exception>(_ => { result += value; });
                break;
            case 3:
                await (isFailed
                    ? ValueTask.FromException(new())
                    : ValueTask.CompletedTask)
                    .Catch<Exception>(_ =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 4:
                await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .Catch(() => { result += value; });
                break;
            case 5:
                await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .Catch(() =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 6:
                result = await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .Catch(() => result + value);
                break;
            case 7:
                result = await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .Catch(() => ValueTask.FromResult(result + value));
                break;
            case 8:
                await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .Catch<int, Exception>(_ => { result += value; });
                break;
            case 9:
                await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .Catch<int, Exception>(_ =>
                    {
                        result += value;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 10:
                result = await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .Catch<int, Exception>(_ => result + value);
                break;
            case 11:
                result = await (isFailed
                    ? ValueTask.FromException<int>(new())
                    : ValueTask.FromResult(result))
                    .Catch<int, Exception>(_ => ValueTask.FromResult(result + value));
                break;
            default:
                await (isFailed
                    ? ValueTask.FromException(new())
                    : ValueTask.CompletedTask)
                    .Catch(() => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }
}
