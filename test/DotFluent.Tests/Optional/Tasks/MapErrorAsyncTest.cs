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
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, Exception>(new());
        Func<Exception, Task<Exception>> mapper = null;

        await result
            .Awaiting(x => x.MapErrorAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MapErrorAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);

        await result
            .Awaiting(x => x.MapErrorAsync(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MapErrorAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 0)]
    [TestCase(1, 1)]
    [TestCase(null, 0)]
    [TestCase(null, 1)]
    public async Task MapErrorAsync(int? source, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .MapErrorAsync(x => Task.FromResult(++x))
                .MatchAsync(x => x == source, x => x >= 1),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .MapErrorAsync(x => Task.FromResult<Exception>(new AggregateException(x)))
                .MatchAsync(x => x == source, x => x is AggregateException)
        }; 

        currentResult.ShouldBeTrue();
    }

    [Test]
    public async Task MapErrorAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task MapErrorAsyncMapperCanceled()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        using (var cts = new CancellationTokenSource())
            await result
                .Awaiting(x => x.MapErrorAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await result2
                .Awaiting(x => x.MapErrorAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
