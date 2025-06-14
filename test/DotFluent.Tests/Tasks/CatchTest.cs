using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskCatchTest
{
    #region Methods

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
                await Task
                    .Run(() => isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                    .Catch(() =>
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
                    .Catch<Exception>(_ => { result += value; });
                break;
            case 3:
                await Task
                    .Run(() => isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                    .Catch<Exception>(_ =>
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
                    .Catch(() => result + value);
                break;
            case 5:
                result = await Task
                    .Run(() => isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                    .Catch(() => Task.FromResult(result + value));
                break;
            case 6:
                result = await Task
                    .Run(() => isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                    .Catch<int, Exception>(_ => result + value);
                break;
            case 7:
                result = await Task
                    .Run(() => isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                    .Catch<int, Exception>(_ => Task.FromResult(result + value));
                break;
            default:
                await Task
                    .Run(() => isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                    .Catch(() => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }

    #endregion
}
