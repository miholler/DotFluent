using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableSingleOrDefaultAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.SingleOrDefaultAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(() => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int> defaultFactory = null;
        Func<ValueTask<int>> taskDefaultFactory = null;

        await source
            .Awaiting(x => x.SingleOrDefaultAsync(defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, bool> predicate = null;
        Func<int, ValueTask<bool>> taskPredicate = null;

        await source
            .Awaiting(x => x.SingleOrDefaultAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(predicate, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(taskPredicate, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(predicate, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(taskPredicate, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(predicate, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(taskPredicate, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MultipleElementsThrowsException()
    {
        var source = AsyncSequence.Create(1, 2, 3, 4);

        await source
            .Awaiting(x => x.SingleOrDefaultAsync(y => y % 2 == 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(y => ValueTask.FromResult(y % 2 == 0)))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(y => y % 2 == 0, 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(y => ValueTask.FromResult(y % 2 == 0), 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(y => y % 2 == 0, () => 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(y => ValueTask.FromResult(y % 2 == 0), () => 0))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(y => y % 2 == 0, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(y => ValueTask.FromResult(y % 2 == 0), () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0)]
    [TestCase(new int[0], 0, 1)]
    [TestCase(new int[0], 0, 2)]
    [TestCase(new int[0], 0, 3)]
    [TestCase(new int[0], 0, 4)]
    [TestCase(new int[0], 0, 5)]
    [TestCase(new int[0], 0, 6)]
    [TestCase(new int[0], 0, 7)]
    [TestCase(new int[0], 0, 8)]
    [TestCase(new int[0], 0, 9)]
    [TestCase(new int[0], 0, 10)]
    [TestCase(new int[0], 0, 11)]
    [TestCase(new[] { 1 }, 1, 0)]
    [TestCase(new[] { 1 }, 1, 1)]
    [TestCase(new[] { 1 }, 1, 2)]
    [TestCase(new[] { 1 }, 1, 3)]
    [TestCase(new[] { 1 }, 0, 4)]
    [TestCase(new[] { 1 }, 0, 5)]
    [TestCase(new[] { 1 }, 0, 6)]
    [TestCase(new[] { 1 }, 0, 7)]
    [TestCase(new[] { 1 }, 0, 8)]
    [TestCase(new[] { 1 }, 0, 9)]
    [TestCase(new[] { 1 }, 0, 10)]
    [TestCase(new[] { 1 }, 0, 11)]
    [TestCase(new[] { 1, 3, 5 }, 0, 4)]
    [TestCase(new[] { 1, 3, 5 }, 0, 5)]
    [TestCase(new[] { 1, 3, 5 }, 0, 6)]
    [TestCase(new[] { 1, 3, 5 }, 0, 7)]
    [TestCase(new[] { 1, 3, 5 }, 0, 8)]
    [TestCase(new[] { 1, 3, 5 }, 0, 9)]
    [TestCase(new[] { 1, 3, 5 }, 0, 10)]
    [TestCase(new[] { 1, 3, 5 }, 0, 11)]
    [TestCase(new[] { 1, 2, 3 }, 2, 4)]
    [TestCase(new[] { 1, 2, 3 }, 2, 5)]
    [TestCase(new[] { 1, 2, 3 }, 2, 6)]
    [TestCase(new[] { 1, 2, 3 }, 2, 7)]
    [TestCase(new[] { 1, 2, 3 }, 2, 8)]
    [TestCase(new[] { 1, 2, 3 }, 2, 9)]
    [TestCase(new[] { 1, 2, 3 }, 2, 10)]
    [TestCase(new[] { 1, 2, 3 }, 2, 11)]
    public async Task SingleOrDefaultAsync(IEnumerable<int> source, int expectedResult, int overload)
    {
        var items = source.ToAsyncEnumerable();
        var result = overload switch
        {
            1 => await items.SingleOrDefaultAsync(0),
            2 => await items.SingleOrDefaultAsync(() => 0),
            3 => await items.SingleOrDefaultAsync(() => ValueTask.FromResult(0)),
            4 => await items.SingleOrDefaultAsync(x => x % 2 == 0),
            5 => await items.SingleOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0)),
            6 => await items.SingleOrDefaultAsync(x => x % 2 == 0, 0),
            7 => await items.SingleOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), 0),
            8 => await items.SingleOrDefaultAsync(x => x % 2 == 0, () => 0),
            9 => await items.SingleOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), () => 0),
            10 => await items.SingleOrDefaultAsync(x => x % 2 == 0, () => ValueTask.FromResult(0)),
            11 => await items.SingleOrDefaultAsync(x => ValueTask.FromResult(x % 2 == 0), () => ValueTask.FromResult(0)),
            _ => await items.SingleOrDefaultAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task SingleOrDefaultAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.SingleOrDefaultAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(() => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(() => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => false, () => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.SingleOrDefaultAsync(_ => ValueTask.FromResult(false), () => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
