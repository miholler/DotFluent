using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableFirstOrDefaultAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.FirstOrDefaultAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(() => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int> defaultFactory = null;
        Func<ValueTask<int>> taskDefaultFactory = null;

        await source
            .Awaiting(x => x.FirstOrDefaultAsync(defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.FirstOrDefaultAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(predicate, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(taskPredicate, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(predicate, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(taskPredicate, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(predicate, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(taskPredicate, () => ValueTask.FromResult(0)))
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
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 0, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 1, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 0, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 1, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 0, 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 1, 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 0, 3)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 1, 3)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 4)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 4)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 5)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 5)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 6)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 6)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 7)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 7)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 8)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 8)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 9)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 9)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 10)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 10)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 11)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 11)]
    public async Task FirstOrDefaultAsync(IEnumerable<int> source, int expectedResult, int collectionType, int overload)
    {
        var items = collectionType switch
        {
            1 => source.ToAsyncIterator(),
            _ => source.ToAsyncEnumerable()
        };
        var result = overload switch
        {
            1 => await items.FirstOrDefaultAsync(0),
            2 => await items.FirstOrDefaultAsync(() => 0),
            3 => await items.FirstOrDefaultAsync(() => ValueTask.FromResult(0)),
            4 => await items.FirstOrDefaultAsync(x => x % 2 == 0),
            5 => await items.FirstOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0)),
            6 => await items.FirstOrDefaultAsync(x => x % 2 == 0, 0),
            7 => await items.FirstOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), 0),
            8 => await items.FirstOrDefaultAsync(x => x % 2 == 0, () => 0),
            9 => await items.FirstOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), () => 0),
            10 => await items.FirstOrDefaultAsync(x => x % 2 == 0, () => ValueTask.FromResult(0)),
            11 => await items.FirstOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), () => ValueTask.FromResult(0)),
            _ => await items.FirstOrDefaultAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FirstOrDefaultAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.FirstOrDefaultAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(() => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(() => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => false, () => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstOrDefaultAsync(_ => ValueTask.FromResult(false), () => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
