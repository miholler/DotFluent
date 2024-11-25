using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableLastOrDefaultAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.LastOrDefaultAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(() => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int> defaultFactory = null;
        Func<ValueTask<int>> taskDefaultFactory = null;

        await source
            .Awaiting(x => x.LastOrDefaultAsync(defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.LastOrDefaultAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(predicate, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(taskPredicate, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(predicate, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(taskPredicate, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(predicate, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(taskPredicate, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0, 0)]
    [TestCase(new int[0], 0, 1, 0)]
    [TestCase(new int[0], 0, 0, 1)]
    [TestCase(new int[0], 0, 1, 1)]
    [TestCase(new int[0], 0, 0, 2)]
    [TestCase(new int[0], 0, 1, 2)]
    [TestCase(new int[0], 0, 0, 3)]
    [TestCase(new int[0], 0, 1, 3)]
    [TestCase(new int[0], 0, 0, 4)]
    [TestCase(new int[0], 0, 1, 4)]
    [TestCase(new int[0], 0, 0, 5)]
    [TestCase(new int[0], 0, 1, 5)]
    [TestCase(new int[0], 0, 0, 6)]
    [TestCase(new int[0], 0, 1, 6)]
    [TestCase(new int[0], 0, 0, 7)]
    [TestCase(new int[0], 0, 1, 7)]
    [TestCase(new int[0], 0, 0, 8)]
    [TestCase(new int[0], 0, 1, 8)]
    [TestCase(new int[0], 0, 0, 9)]
    [TestCase(new int[0], 0, 1, 9)]
    [TestCase(new int[0], 0, 0, 10)]
    [TestCase(new int[0], 0, 1, 10)]
    [TestCase(new int[0], 0, 0, 11)]
    [TestCase(new int[0], 0, 1, 11)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 3)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 3)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 4)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 4)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 5)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 5)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 6)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 6)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 7)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 7)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 8)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 8)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 9)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 9)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 10)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 10)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 11)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 11)]
    public async Task LastOrDefaultAsync(IEnumerable<int> source, int expectedResult, int collectionType, int overload)
    {
        var items = collectionType switch
        {
            1 => source.ToAsyncIterator(),
            _ => source.ToAsyncEnumerable()
        };
        var result = overload switch
        {
            1 => await items.LastOrDefaultAsync(0),
            2 => await items.LastOrDefaultAsync(() => 0),
            3 => await items.LastOrDefaultAsync(() => ValueTask.FromResult(0)),
            4 => await items.LastOrDefaultAsync(x => x % 2 == 0),
            5 => await items.LastOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0)),
            6 => await items.LastOrDefaultAsync(x => x % 2 == 0, 0),
            7 => await items.LastOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), 0),
            8 => await items.LastOrDefaultAsync(x => x % 2 == 0, () => 0),
            9 => await items.LastOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), () => 0),
            10 => await items.LastOrDefaultAsync(x => x % 2 == 0, () => ValueTask.FromResult(0)),
            11 => await items.LastOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), () => ValueTask.FromResult(0)),
            _ => await items.LastOrDefaultAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task LastOrDefaultAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.LastOrDefaultAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(() => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(() => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => false, () => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastOrDefaultAsync(_ => ValueTask.FromResult(false), () => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
