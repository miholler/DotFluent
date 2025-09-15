using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ResultMapErrorAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperNullThrowsException()
    {
        var resultTask = ResultTask.Error<int>(new());
        var result2Task = ResultTask.Error<int, Exception>(new());
        Func<Exception, Exception> mapper = null;
        Func<Exception, Task<Exception>> taskMapper = null;

        await resultTask
            .Awaiting(x => x.MapErrorAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 0)]
    [TestCase(1, 1)]
    [TestCase(1, 2)]
    [TestCase(1, 3)]
    [TestCase(null, 0)]
    [TestCase(null, 1)]
    [TestCase(null, 2)]
    [TestCase(null, 3)]
    public async Task MapErrorAsync(int? source, int overload)
    {
        var currentResult = overload switch
        {
            2 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .MapErrorAsync(x => ++x)
                .MatchAsync(x => x == source, x => x >= 1),
            3 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .MapErrorAsync(x => Task.FromResult(++x))
                .MatchAsync(x => x == source, x => x >= 1),
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .MapErrorAsync(x => Task.FromResult<Exception>(new AggregateException(x)))
                .MatchAsync(x => x == source, x => x is AggregateException),
            _ => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .MapErrorAsync(x => new AggregateException(x))
                .MatchAsync(x => x == source, x => x is AggregateException)
        };

        currentResult.ShouldBeTrue();
    }

    [Test]
    public async Task MapErrorAsyncCanceled()
    {
        var resultTask = ResultTask.Error<int>(new());
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => y, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(y => y, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
