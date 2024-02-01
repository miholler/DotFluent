using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ResultMapErrorAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;

        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperNullThrowsException()
    {
        var resultTask = ResultTask.Error<int>(new());
        Func<Exception, Exception> mapper = null;
        Func<Exception, Task<Exception>> taskMapper = null;

        await resultTask
            .Awaiting(x => x.MapErrorAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 0)]
    [TestCase(1, 1)]
    [TestCase(null, 0)]
    [TestCase(null, 1)]
    public async Task MapErrorAsync(int? source, int overload)
    {
        var resultTask = source.Match(ResultTask.Ok, () => ResultTask.Error<int>(new()));
        var currentResult = overload switch
        {
            1 => await resultTask
                .MapErrorAsync(x => Task.FromResult<Exception>(new AggregateException(x)))
                .MatchAsync(x => x == source, x => x is AggregateException),
            _ => await resultTask
                .MapErrorAsync(x => new AggregateException(x))
                .MatchAsync(x => x == source, x => x is AggregateException)
        };

        currentResult.ShouldBeTrue();
    }

    [Test]
    public async Task MapErrorAsyncCanceled()
    {
        var resultTask = ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => y, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
