using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableElementAtOrDefaultAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, () => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, () => ValueTask.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var source = AsyncSequence.Empty<int>();
        Func<int> defaultFactory = null;
        Func<ValueTask<int>> taskDefaultFactory = null;

        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, taskDefaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0, 0)]
    [TestCase(new int[0], 0, 0, 1)]
    [TestCase(new int[0], 0, 0, 2)]
    [TestCase(new int[0], 0, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 2)]
    [TestCase(new[] { 1, 2, 3 }, 3, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, -3, 0, 0)]
    [TestCase(new[] { 1, 2, 3 }, -3, 0, 1)]
    [TestCase(new[] { 1, 2, 3 }, -3, 0, 2)]
    [TestCase(new[] { 1, 2, 3 }, -3, 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 2)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 3)]
    public async Task ElementAtOrDefaultAsync(IEnumerable<int> source, int index, int expectedResult, int overload)
    {
        var items = source.ToAsyncEnumerable();
        var result = overload switch
        {
            1 => await items.ElementAtOrDefaultAsync(index, 0),
            2 => await items.ElementAtOrDefaultAsync(index, () => 0),
            3 => await items.ElementAtOrDefaultAsync(index, () => ValueTask.FromResult(0)),
            _ => await items.ElementAtOrDefaultAsync(index)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ElementAtOrDefaultAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, () => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ElementAtOrDefaultAsync(0, () => ValueTask.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
