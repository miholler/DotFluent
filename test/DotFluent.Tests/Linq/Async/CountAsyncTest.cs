using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableCountAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.CountAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CountAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CountAsync(_ => new ValueTask<bool>(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.CountAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.CountAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0, 0)]
    [TestCase(new int[0], 0, 1, 0)]
    [TestCase(new int[0], 0, 0, 1)]
    [TestCase(new int[0], 0, 1, 1)]
    [TestCase(new int[0], 0, 0, 2)]
    [TestCase(new int[0], 0, 1, 2)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 3, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 1, 1, 1)]
    [TestCase(new[] { 1, 2, 3 }, 1, 0, 2)]
    [TestCase(new[] { 1, 2, 3 }, 1, 1, 2)]
    public async Task CountAsync(IEnumerable<int> source, int expectedResult, int collectionType, int overload)
    {
        var items = collectionType switch
        {
            1 => AsyncEnumerable.Create(source),
            _ => source.ToAsyncEnumerable()
        };
        var result = overload switch
        {
            1 => await items.CountAsync(x => x % 2 == 0),
            2 => await items.CountAsync(x => new ValueTask<bool>(x % 2 == 0)),
            _ => await items.CountAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task CountAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.CountAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.CountAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.CountAsync(_ => new ValueTask<bool>(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
