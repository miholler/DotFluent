using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableForEachAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ForEachAsync(y => y++))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, i) => y += i))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync(y =>
            {
                y++;
                return Task.CompletedTask;
            }))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, i) =>
            {
                y += i;
                return Task.CompletedTask;
            }))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ActionNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Action<int> action = null;
        Action<int, int> indexAction = null;
        Func<int, Task> taskAction = null;
        Func<int, int, Task> taskIndexAction = null;

        await source
            .Awaiting(x => x.ForEachAsync(action))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync(indexAction))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync(taskAction))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync(taskIndexAction))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ActionReturningNullThrowsException()
    {
        var source = AsyncSequence.Create(1, 2, 3);

        await source
            .Awaiting(x => x.ForEachAsync(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.ForEachAsync((_, _) => default))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0)]
    [TestCase(new int[0], 0, 1)]
    [TestCase(new int[0], 0, 2)]
    [TestCase(new int[0], 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 6, 0)]
    [TestCase(new[] { 1, 2, 3 }, 9, 1)]
    [TestCase(new[] { 1, 2, 3 }, 6, 2)]
    [TestCase(new[] { 1, 2, 3 }, 9, 3)]
    public async Task ForEachAsync(IEnumerable<int> source, int expectedResult, int overload)
    {
        var items = source.ToAsyncEnumerable();
        var result = 0;

        switch (overload)
        {
            case 1:
                await items.ForEachAsync((x, i) => result += x + i);
                break;
            case 2:
                await items.ForEachAsync(x =>
                {
                    result += x;
                    return Task.CompletedTask;
                });
                break;
            case 3:
                await items.ForEachAsync((x, i) =>
                {
                    result += x + i;
                    return Task.CompletedTask;
                });
                break;
            default:
                await items.ForEachAsync(x => result += x);
                break;
        }

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ForEachAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ForEachAsync(y => y++, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, i) => y += i, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ForEachAsync(y =>
            {
                y++;
                return Task.CompletedTask;
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, i) =>
            {
                y += i;
                return Task.CompletedTask;
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
