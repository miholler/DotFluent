using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableContainsAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ContainsAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ContainsAsync(0, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ContainsAsync(0, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, false, 0)]
    [TestCase(new int[0], 0, false, 1)]
    [TestCase(new int[0], 0, false, 2)]
    [TestCase(new[] { 1, 2, 3 }, 0, false, 0)]
    [TestCase(new[] { 1, 2, 3 }, 0, false, 1)]
    [TestCase(new[] { 1, 2, 3 }, 0, false, 2)]
    [TestCase(new[] { 1, 2, 3 }, 2, true, 0)]
    [TestCase(new[] { 1, 2, 3 }, 2, true, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, true, 2)]
    public async Task ContainsAsync(IEnumerable<int> source, int value, bool expectedResult, int overload)
    {
        var items = source.ToAsyncEnumerable();
        var result = overload switch
        {
            1 => await items.ContainsAsync(value, (x, y) => x == y),
            2 => await items.ContainsAsync(value, EqualityComparer<int>.Default),
            _ => await items.ContainsAsync(value)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ContainsAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ContainsAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ContainsAsync(0, (y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ContainsAsync(0, EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
