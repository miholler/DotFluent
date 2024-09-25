using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class ToArrayAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ToArrayAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0)]
    [TestCase(new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1)]
    public async Task ToArrayAsync(IEnumerable<int> source, int collectionType)
    {
        var result = collectionType switch
        {
            1 => await AsyncEnumerable
                .Create(source)
                .ToArrayAsync(),
            _ => await source
                .ToAsyncEnumerable()
                .ToArrayAsync()
        };

        result.ShouldBe(source);
    }

    [Test]
    public async Task ToArrayAsyncCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await Array
            .Empty<int>()
            .ToAsyncEnumerable()
            .Awaiting(x => x.ToArrayAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
