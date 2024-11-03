using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableAllAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.AllAsync(y => y % 2 == 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AllAsync(y => new ValueTask<bool>(y % 2 == 0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.AllAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AllAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], true, 0)]
    [TestCase(new int[0], true, 1)]
    [TestCase(new[] { 2, 4, 6 }, true, 0)]
    [TestCase(new[] { 2, 4, 6 }, true, 1)]
    [TestCase(new[] { 1, 2, 3 }, false, 0)]
    [TestCase(new[] { 1, 2, 3 }, false, 1)]
    public async Task AllAsync(IEnumerable<int> source, bool expectedResult, int overload)
    {
        var items = source.ToAsyncEnumerable();
        var result = overload switch
        {
            1 => await items.AllAsync(x => new ValueTask<bool>(x % 2 == 0)),
            _ => await items.AllAsync(x => x % 2 == 0)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task AllAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.AllAsync(y => y % 2 == 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AllAsync(y => new ValueTask<bool>(y % 2 == 0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
