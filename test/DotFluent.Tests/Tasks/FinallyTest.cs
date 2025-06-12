using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskFinallyTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task source = null;
        Task<int> genericSource = null;

        await source
            .Awaiting(x => x.Finally(() => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.Finally(() => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericSource
            .Awaiting(x => x.Finally(() => { }))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericSource
            .Awaiting(x => x.Finally(() => Task.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ActionNullThrowsException()
    {
        var source = Task.CompletedTask;
        var genericSource = Task.FromResult(0);
        Action action = null;

        await source
            .Awaiting(x => x.Finally(action))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericSource
            .Awaiting(x => x.Finally(action))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorNullThrowsException()
    {
        var source = Task.CompletedTask;
        var genericSource = Task.FromResult(0);
        Func<Task> selector = null;

        await source
            .Awaiting(x => x.Finally(selector))
            .ShouldThrowAsync<ArgumentNullException>();
        await genericSource
            .Awaiting(x => x.Finally(selector))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorReturningNullThrowsException()
    {
        var source = Task.CompletedTask;
        var genericSource = Task.FromResult(0);

        await source
            .Awaiting(x => x.Finally(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await genericSource
            .Awaiting(x => x.Finally(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 2, 3, 0)]
    [TestCase(1, 2, 3, 1)]
    [TestCase(1, 2, 3, 2)]
    [TestCase(1, 2, 3, 3)]
    public async Task Finally(int source, int value, int expectedResult, int overload)
    {
        var result = source;

        switch (overload)
        {
            case 1:
                await Task.CompletedTask.Finally(() =>
                {
                    result += value;
                    return Task.CompletedTask;
                });
                break;
            case 2:
                await Task
                    .FromResult(result)
                    .Finally(() => { result += value; });
                break;
            case 3:
                await Task
                    .FromResult(result)
                    .Finally(() =>
                    {
                        result += value;
                        return Task.CompletedTask;
                    });
                break;
            default:
                await Task.CompletedTask.Finally(() => { result += value; });
                break;
        }
        result.ShouldBe(expectedResult);
    }

    #endregion
}
