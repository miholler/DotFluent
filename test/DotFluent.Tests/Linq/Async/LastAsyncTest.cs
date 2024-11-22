using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableLastAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.LastAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.LastAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LastAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task EmptySequenceThrowsException()
    {
        var source = AsyncSequence.Empty<int>();

        await source
            .Awaiting(x => x.LastAsync())
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.LastAsync(_ => false))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.LastAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 0, 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, 4, 1, 2)]
    public async Task LastAsync(IEnumerable<int> source, int expectedResult, int collectionType, int overload)
    {
        var items = collectionType switch
        {
            1 => source.ToAsyncIterator(),
            _ => source.ToAsyncEnumerable()
        };
        var result = overload switch
        {
            1 => await items.LastAsync(x => x % 2 == 0),
            2 => await items.LastAsync(x => ValueTask.FromResult(x % 2 == 0)),
            _ => await items.LastAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task LastAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.LastAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LastAsync(_ => ValueTask.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
