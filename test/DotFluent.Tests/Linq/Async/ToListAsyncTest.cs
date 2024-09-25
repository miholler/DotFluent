using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class ToListAsyncTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ToListAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0)]
    [TestCase(new int[0], 1)]
    [TestCase(new[] { 1, 2, 3 }, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1)]
    public async Task ToListAsync(IEnumerable<int> source, int collectionType)
    {
        var result = collectionType switch
        {
            1 => await AsyncEnumerable
                .Create(source)
                .ToListAsync(),
            _ => await source
                .ToAsyncEnumerable()
                .ToListAsync()
        };

        result.ShouldBe(source);
    }

    [Test]
    public async Task ToListAsyncCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await Array
            .Empty<int>()
            .ToAsyncEnumerable()
            .Awaiting(x => x.ToListAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
