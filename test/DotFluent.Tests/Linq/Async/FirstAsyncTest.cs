using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableFirstAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.FirstAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.FirstAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.FirstAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task EmptySequenceThrowsException()
    {
        var source = AsyncSequence.Empty<int>();

        await source
            .Awaiting(x => x.FirstAsync())
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.FirstAsync(_ => false))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.FirstAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 0, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1, 1, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 0, 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 1, 2)]
    public async Task FirstAsync(IEnumerable<int> source, int expectedResult, int collectionType, int overload)
    {
        var items = collectionType switch
        {
            1 => source.ToAsyncIterator(),
            _ => source.ToAsyncEnumerable()
        };
        var result = overload switch
        {
            1 => await items.FirstAsync(x => x % 2 == 0),
            2 => await items.FirstAsync(x => ValueTask.FromResult(x % 2 == 0)),
            _ => await items.FirstAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FirstAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.FirstAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.FirstAsync(_ => ValueTask.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
