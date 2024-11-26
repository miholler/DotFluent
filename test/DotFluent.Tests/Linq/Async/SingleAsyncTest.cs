using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableSingleAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.SingleAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.SingleAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task EmptySequenceThrowsException()
    {
        var source = AsyncSequence.Empty<int>();

        await source
            .Awaiting(x => x.SingleAsync())
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleAsync(_ => false))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    public async Task MultipleElementsThrowsException()
    {
        var source = AsyncSequence.Create(1, 2, 3, 4);

        await source
            .Awaiting(x => x.SingleAsync())
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleAsync(y => y % 2 == 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleAsync(y => ValueTask.FromResult(y % 2 == 0)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(new[] { 1 }, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 2)]
    public async Task SingleAsync(IEnumerable<int> source, int expectedResult, int overload)
    {
        var items = source.ToAsyncEnumerable();
        var result = overload switch
        {
            1 => await items.SingleAsync(x => x % 2 == 0),
            2 => await items.SingleAsync(x => ValueTask.FromResult(x % 2 == 0)),
            _ => await items.SingleAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task SingleAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.SingleAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleAsync(_ => ValueTask.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
