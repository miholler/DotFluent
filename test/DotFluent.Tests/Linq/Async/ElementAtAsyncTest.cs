using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableElementAtAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ElementAtAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task IndexOutOfRangeThrowsException()
    {
        var source = AsyncSequence.Empty<int>();

        await source
            .Awaiting(x => x.ElementAtAsync(-1))
            .ShouldThrowAsync<ArgumentOutOfRangeException>();
        await source
            .Awaiting(x => x.ElementAtAsync(1))
            .ShouldThrowAsync<ArgumentOutOfRangeException>();
    }

    [Test]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 2, 1)]
    public async Task ElementAtAsync(IEnumerable<int> source, int index, int expectedResult, int collectionType)
    {
        var items = collectionType switch
        {
            1 => source.ToAsyncIterator(),
            _ => source.ToAsyncEnumerable()
        };
        var result = await items.ElementAtAsync(index);

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ElementAtAsyncCanceled()
    {
        var source = AsyncSequence.Empty<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ElementAtAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
