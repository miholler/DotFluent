using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableToHashSetAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ToHashSetAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToHashSetAsync((y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToHashSetAsync((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToHashSetAsync(EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ComparisonNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        EqualityComparison<int> comparison = null;

        await source
            .Awaiting(x => x.ToHashSetAsync(comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToHashSetAsync(comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task HashCodeSelectorNullDoesNotThrowException()
    {
        var source = AsyncSequence.Empty<int>();
        HashFunc<int> hashCodeSelector = null;

        await source
            .Awaiting(x => x.ToHashSetAsync((y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
    }

    [Test]
    [TestCase(new int[0], 0)]
    [TestCase(new int[0], 1)]
    [TestCase(new int[0], 2)]
    [TestCase(new int[0], 3)]
    [TestCase(new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2)]
    [TestCase(new[] { 1, 2, 3 }, 3)]
    public async Task ToHashSetAsync(IEnumerable<int> source, int overload)
    {
        var items = source.ToAsyncEnumerable();
        var result = overload switch
        {
            1 => await items.ToHashSetAsync((x, y) => x == y),
            2 => await items.ToHashSetAsync((x, y) => x == y, x => x.GetHashCode()),
            3 => await items.ToHashSetAsync(EqualityComparer<int>.Default),
            _ => await items.ToHashSetAsync()
        };

        result.ShouldBe(new HashSet<int>(source));
    }

    [Test]
    public async Task ToHashSetAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ToHashSetAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToHashSetAsync((y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToHashSetAsync((y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToHashSetAsync(EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
