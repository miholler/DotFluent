using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableAnyAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.AnyAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AnyAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AnyAsync(_ => new ValueTask<bool>(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.AnyAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AnyAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], false, 0, 0)]
    [TestCase(new int[0], false, 1, 0)]
    [TestCase(new int[0], false, 2, 0)]
    [TestCase(new int[0], false, 0, 1)]
    [TestCase(new int[0], false, 1, 1)]
    [TestCase(new int[0], false, 2, 1)]
    [TestCase(new int[0], false, 0, 2)]
    [TestCase(new int[0], false, 1, 2)]
    [TestCase(new int[0], false, 2, 2)]
    [TestCase(new[] { 1, 2, 3 }, true, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, true, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, true, 2, 0)]
    [TestCase(new[] { 1, 2, 3 }, true, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, true, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, true, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, true, 0, 2)]
    [TestCase(new[] { 1, 2, 3 }, true, 1, 2)]
    [TestCase(new[] { 1, 2, 3 }, true, 2, 2)]
    public async Task AnyAsync(IEnumerable<int> source, bool expectedResult, int collectionType, int overload)
    {
        var items = collectionType switch
        {
            1 => source.ToAsyncIterator(),
            2 => source
                .ToIterator()
                .ToAsyncIterator(),
            _ => source.ToAsyncEnumerable()
        };
        var result = overload switch
        {
            1 => await items.AnyAsync(x => x % 2 == 0),
            2 => await items.AnyAsync(x => new ValueTask<bool>(x % 2 == 0)),
            _ => await items.AnyAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task AnyAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.AnyAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AnyAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AnyAsync(_ => new ValueTask<bool>(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
