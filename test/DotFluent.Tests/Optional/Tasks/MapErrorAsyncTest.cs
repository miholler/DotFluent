using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ResultMapErrorAsyncTest
{
    #region Methods

    [Test]
    public async Task MapperNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());
        Func<Exception, Task<Exception>> mapper = null;

        await result
            .Awaiting(x => x.MapErrorAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());

        await result
            .Awaiting(x => x.MapErrorAsync(_ => default(Task<Exception>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1)]
    [TestCase(null)]
    public async Task MapErrorAsync(int? source)
    {
        var result = await source.Match(ResultTask.Ok, () => ResultTask.Error<int>(new()));
        var currentResult = await result
            .MapErrorAsync(x => Task.FromResult<Exception>(new AggregateException(x)))
            .MatchAsync(x => x == source, x => x is AggregateException);

        currentResult.ShouldBeTrue();
    }

    [Test]
    public async Task MapErrorAsyncCanceled()
    {
        var result = await ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task MapErrorAsyncMappingCanceled()
    {
        var result = await ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();

        await result
            .Awaiting(x => x.MapErrorAsync(y =>
            {
                cts.Cancel();
                return Task.FromResult(y);
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
