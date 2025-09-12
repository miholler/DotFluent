using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class TaskFinallyTest
{
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
    [TestCase(1, 2, 3, true, 0)]
    [TestCase(1, 2, 3, false, 0)]
    [TestCase(1, 2, 3, true, 1)]
    [TestCase(1, 2, 3, false, 1)]
    [TestCase(1, 2, 3, true, 2)]
    [TestCase(1, 2, 3, false, 2)]
    [TestCase(1, 2, 3, true, 3)]
    [TestCase(1, 2, 3, false, 3)]
    public async Task Finally(int source, int value, int expectedResult, bool isFailed, int overload)
    {
        var result = source;
        try
        {
            switch (overload)
            {
                case 1:
                    await (isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                        .Finally(() =>
                        {
                            result += value;
                            return Task.CompletedTask;
                        });
                    break;
                case 2:
                    await (isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                        .Finally(() => { result += value; });
                    break;
                case 3:
                    await (isFailed
                        ? Task.FromException<int>(new())
                        : Task.FromResult(result))
                        .Finally(() =>
                        {
                            result += value;
                            return Task.CompletedTask;
                        });
                    break;
                default:
                    await (isFailed
                        ? Task.FromException(new())
                        : Task.CompletedTask)
                        .Finally(() => { result += value; });
                    break;
            }
        }
        catch (Exception ex)
        {
            ex.ShouldBeOfType<Exception>();
        }
        finally
        {
            result.ShouldBe(expectedResult);
        }
    }
}

[TestFixture]
public sealed class ValueTaskFinallyTest
{
    [Test]
    public async Task ActionNullThrowsException()
    {
        Action action = null;

        await action
            .Awaiting(x => ValueTask.CompletedTask.Finally(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await action
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Finally(x))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorNullThrowsException()
    {
        Func<ValueTask> selector = null;

        await selector
            .Awaiting(x => ValueTask.CompletedTask.Finally(x))
            .ShouldThrowAsync<ArgumentNullException>();
        await selector
            .Awaiting(x => ValueTask
                .FromResult(0)
                .Finally(x))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, 3, true, 0)]
    [TestCase(1, 2, 3, false, 0)]
    [TestCase(1, 2, 3, true, 1)]
    [TestCase(1, 2, 3, false, 1)]
    [TestCase(1, 2, 3, true, 2)]
    [TestCase(1, 2, 3, false, 2)]
    [TestCase(1, 2, 3, true, 3)]
    [TestCase(1, 2, 3, false, 3)]
    public async Task Finally(int source, int value, int expectedResult, bool isFailed, int overload)
    {
        var result = source;
        try
        {
            switch (overload)
            {
                case 1:
                    await (isFailed
                        ? ValueTask.FromException(new())
                        : ValueTask.CompletedTask)
                        .Finally(() => isFailed
                            ? ValueTask.FromException(new())
                            : ValueTask.CompletedTask)
                        .Finally(() =>
                        {
                            result += value;
                            return ValueTask.CompletedTask;
                        });
                    break;
                case 2:
                    await (isFailed
                        ? ValueTask.FromException<int>(new())
                        : ValueTask.FromResult(result))
                        .Finally(() => { result += value; });
                    break;
                case 3:
                    await (isFailed
                        ? ValueTask.FromException<int>(new())
                        : ValueTask.FromResult(result))
                        .Finally(() => isFailed
                            ? ValueTask.FromException(new())
                            : ValueTask.CompletedTask)
                        .Finally(() =>
                        {
                            result += value;
                            return ValueTask.CompletedTask;
                        });
                    break;
                default:
                    await (isFailed
                        ? ValueTask.FromException(new())
                        : ValueTask.CompletedTask)
                        .Finally(() => { result += value; });
                    break;
            }
        }
        catch (Exception ex)
        {
            ex.ShouldBeOfType<Exception>();
        }
        finally
        {
            result.ShouldBe(expectedResult);
        }
    }
}
