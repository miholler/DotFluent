using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class MapAsyncTest
{
    #region Methods

    [Test]
    public async Task MapperNullThrowsException()
    {
        var option = await OptionTask.None<int>();
        Func<int, Task<int>> mapper = null;

        await option
            .Awaiting(x => x.MapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var option = await OptionTask.Some(0);

        await option
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 2 })]
    public async Task MapAsync(int? source, IEnumerable<int> expectedResult)
    {
        var option = await source.ToOptionAsync();
        var result = await option.MapAsync(x => Task.FromResult(++x));

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task MapAsyncCanceled()
    {
        var option = await OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.MapAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task MapAsyncMappingCanceled()
    {
        var option = await OptionTask.Some(0);
        using var cts = new CancellationTokenSource();

        await option
            .Awaiting(x => x.MapAsync(y =>
            {
                cts.Cancel();
                return Task.FromResult(y);
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
