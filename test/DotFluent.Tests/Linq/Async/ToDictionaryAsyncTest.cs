using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableToDictionaryAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;
        IAsyncEnumerable<KeyValuePair<int, int>> pairSource = null;
        IAsyncEnumerable<ValueTuple<int, int>> tupleSource = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task KeySelectorNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, int> keySelector = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, y => y, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, y => y, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, ValueTask.FromResult))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, ValueTask.FromResult, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, ValueTask.FromResult, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, ValueTask.FromResult, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ElementSelectorNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int, int> elementSelector = null;
        Func<int, ValueTask<int>> taskElementSelector = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, elementSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, elementSelector, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, elementSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, elementSelector, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, taskElementSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, taskElementSelector, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, taskElementSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, taskElementSelector, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ComparisonNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        var pairSource = AsyncSequence.Empty<KeyValuePair<int, int>>();
        var tupleSource = AsyncSequence.Empty<ValueTuple<int, int>>();
        EqualityComparison<int> comparison = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task HashCodeSelectorNullDoesNotThrowException()
    {
        var source = AsyncSequence.Empty<int>();
        var pairSource = AsyncSequence.Empty<KeyValuePair<int, int>>();
        var tupleSource = AsyncSequence.Empty<ValueTuple<int, int>>();
        HashFunc<int> hashCodeSelector = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
    }

    [Test]
    public Task ToDictionaryAsync()
        => throw new NotImplementedException("Implement as soon as Select method is available!");

    [Test]
    public async Task ToDictionaryAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        var pairSource = AsyncSequence.Empty<KeyValuePair<int, int>>();
        var tupleSource = AsyncSequence.Empty<ValueTuple<int, int>>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, (y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, (y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, ValueTask.FromResult, EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
