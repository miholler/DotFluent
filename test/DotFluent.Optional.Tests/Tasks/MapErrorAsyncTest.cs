using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ResultMapErrorAsyncTest
{
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
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, Exception>(new());
        var result2Task = ResultTask.Error<int, Exception>(new());
        Func<Exception, Exception> mapper = null;
        Func<Exception, Task<Exception>> taskMapper = null;

        await result
            .Awaiting(x => x.MapErrorAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
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
    public async Task MapperReturningNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);

        await result
            .Awaiting(x => x.MapErrorAsync(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(_ => default(Task<Exception>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MapErrorAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 0)]
    [TestCase(1, 1)]
    [TestCase(1, 2)]
    [TestCase(1, 3)]
    [TestCase(1, 4)]
    [TestCase(1, 5)]
    [TestCase(null, 0)]
    [TestCase(null, 1)]
    [TestCase(null, 2)]
    [TestCase(null, 3)]
    [TestCase(null, 4)]
    [TestCase(null, 5)]
    public async Task MapErrorAsync(int? source, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .MapErrorAsync(x => new AggregateException(x))
                .MatchAsync(x => x == source, x => x is AggregateException),
            2 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .MapErrorAsync(x => Task.FromResult<Exception>(new AggregateException(x)))
                .MatchAsync(x => x == source, x => x is AggregateException),
            3 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .MapErrorAsync(x => Task.FromResult(++x))
                .MatchAsync(x => x == source, x => x >= 1),
            4 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .MapErrorAsync(x => ++x)
                .MatchAsync(x => x == source, x => x >= 1),
            5 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
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
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => y, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(y => y, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MapErrorAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task MapErrorAsyncMapperCanceled()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        using (var cts = new CancellationTokenSource())
            await result
                .Awaiting(x => x.MapErrorAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await resultTask
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

        using (var cts = new CancellationTokenSource())
            await result2Task
                .Awaiting(x => x.MapErrorAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
    }
}
