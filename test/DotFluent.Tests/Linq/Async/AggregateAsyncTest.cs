using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableAggregateAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.AggregateAsync((sum, value) => sum + value))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync((sum, value) => ValueTask.FromResult(sum + value)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => sum + value))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => sum + value, sum => sum))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), sum => sum))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => sum + value, ValueTask.FromResult))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), ValueTask.FromResult))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task AccumulatorNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, int, int> accumulator = null;
        Func<int, int, ValueTask<int>> taskAccumulator = null;

        await source
            .Awaiting(x => x.AggregateAsync(accumulator))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(taskAccumulator))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, accumulator))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, taskAccumulator))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, accumulator, sum => sum))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, taskAccumulator, sum => sum))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, accumulator, ValueTask.FromResult))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, taskAccumulator, ValueTask.FromResult))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ResultSelectorNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, int> resultSelector = null;
        Func<int, ValueTask<int>> taskResultSelector = null;

        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => sum + value, resultSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), resultSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => sum + value, taskResultSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), taskResultSelector))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task EmptySequenceThrowsException()
    {
        var source = AsyncSequence.Empty<int>();

        await source
            .Awaiting(x => x.AggregateAsync((sum, value) => sum + value))
            .ShouldThrowAsync<InvalidOperationException>();
        await source
            .Awaiting(x => x.AggregateAsync((sum, value) => ValueTask.FromResult(sum + value)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(new[] { 1, 2, 3 }, 6, 0)]
    [TestCase(new[] { 1, 2, 3 }, 6, 1)]
    [TestCase(new[] { 1, 2, 3 }, 6, 2)]
    [TestCase(new[] { 1, 2, 3 }, 6, 3)]
    [TestCase(new[] { 1, 2, 3 }, 7, 4)]
    [TestCase(new[] { 1, 2, 3 }, 7, 5)]
    [TestCase(new[] { 1, 2, 3 }, 7, 6)]
    [TestCase(new[] { 1, 2, 3 }, 7, 7)]
    public async Task AggregateAsync(IEnumerable<int> source, int expectedResult, int overload)
    {
        var items = source.ToAsyncEnumerable();
        var result = overload switch
        {
            1 => await items.AggregateAsync((sum, value) => ValueTask.FromResult(sum + value)),
            2 => await items.AggregateAsync(0, (sum, value) => sum + value),
            3 => await items.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value)),
            4 => await items.AggregateAsync(0, (sum, value) => sum + value, sum => sum + 1),
            5 => await items.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), sum => sum + 1),
            6 => await items.AggregateAsync(0, (sum, value) => sum + value, sum => ValueTask.FromResult(sum + 1)),
            7 => await items.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), sum => ValueTask.FromResult(sum + 1)),
            _ => await items.AggregateAsync((sum, value) => sum + value)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task AggregateAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.AggregateAsync((sum, value) => sum + value, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AggregateAsync((sum, value) => ValueTask.FromResult(sum + value), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => sum + value, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => sum + value, sum => sum, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), sum => sum, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => sum + value, ValueTask.FromResult, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.AggregateAsync(0, (sum, value) => ValueTask.FromResult(sum + value), ValueTask.FromResult, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
