using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableLongCountAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.LongCountAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LongCountAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LongCountAsync(_ => new ValueTask<bool>(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = Array
            .Empty<int>()
            .ToAsyncEnumerable();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.LongCountAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.LongCountAsync(taskPredicate))
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
    public async Task LongCountAsync(IEnumerable<int> source, long expectedResult, int collectionType, int overload)
    {
        var items = collectionType switch
        {
            1 => AsyncEnumerable.Create(source),
            _ => source.ToAsyncEnumerable()
        };
        var result = overload switch
        {
            1 => await items.LongCountAsync(x => x % 2 == 0),
            2 => await items.LongCountAsync(x => new ValueTask<bool>(x % 2 == 0)),
            _ => await items.LongCountAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task LongCountAsyncCanceled()
    {
        var source = Array
            .Empty<int>()
            .ToAsyncEnumerable();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.LongCountAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LongCountAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.LongCountAsync(_ => new ValueTask<bool>(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
