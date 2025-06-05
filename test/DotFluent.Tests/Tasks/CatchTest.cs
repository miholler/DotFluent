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
        var source = Task.FromResult(0);
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
    [TestCase(1, 2, 3, 0)]
    [TestCase(1, 2, 3, 1)]
    [TestCase(1, 2, 3, 2)]
    [TestCase(1, 2, 3, 3)]
    [TestCase(1, 2, 3, 4)]
    [TestCase(1, 2, 3, 5)]
    public async Task Catch(int source, int value, int expectedResult, int overload)
    {
        var result = source;

        switch (overload)
        {
            case 1:
                await Task
                    .FromException(new())
                    .Catch(() =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 2:
                await Task
                    .FromException(new())
                    .Catch<Exception>(_ => { result += value; });
                break;
            case 3:
                await Task
                    .FromException(new())
                    .Catch<Exception>(_ =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            case 4:
                result = await Task
                    .FromException<int>(new())
                    .Catch(() => result + value);
                break;
            case 5:
                result = await Task
                    .FromException<int>(new())
                    .Catch(() => Task.FromResult(result + value));
                break;
            case 6:
                result = await Task
                    .FromException<int>(new())
                    .Catch<int, Exception>(_ => result + value);
                break;
            case 7:
                result = await Task
                    .FromException<int>(new())
                    .Catch<int, Exception>(_ => Task.FromResult(result + value));
                break;
            default:
                await Task
                    .FromException(new())
                    .Catch(() => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }

    #endregion
}
