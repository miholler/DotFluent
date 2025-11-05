using DotFluent.Tasks;
using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionMapAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.MapAsync(_ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MapAsync(_ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperNullThrowsException()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        Func<int, int> mapper = null;
        Func<int, Task<int>> taskMapper = null;

        await option
            .Awaiting(x => x.MapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.MapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);

        await option
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(null, new int[0], 2)]
    [TestCase(1, new[] { 2 }, 0)]
    [TestCase(1, new[] { 2 }, 1)]
    [TestCase(1, new[] { 2 }, 2)]
    public async Task MapAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .ToOptionAsync()
                .MapAsync(x => ++x),
            2 => await source
                .ToOptionAsync()
                .MapAsync(x => Task.FromResult(++x)),
            _ => await source
                .ToOption()
                .MapAsync(x => Task.FromResult(++x))
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task MapAsyncCanceled()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.MapAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.MapAsync(_ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.MapAsync(_ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task MapAsyncMapperCanceled()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);
        using (var cts = new CancellationTokenSource())
            await option
                .Awaiting(x => x.MapAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await optionTask
                .Awaiting(x => x.MapAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultMapAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.MapAsync(_ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapAsync(_ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MapAsync(_ => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MapAsync(_ => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        Func<int, int> mapper = null;
        Func<int, Task<int>> taskMapper = null;

        await result
            .Awaiting(x => x.MapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.MapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.MapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.MapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var result = Result.Ok(0);
        var resultTask = ResultTask.Ok(0);
        var result2 = Result.Ok<int, int>(0);
        var result2Task = ResultTask.Ok<int, int>(0);

        await result
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, new[] { 2 }, 0)]
    [TestCase(1, new[] { 2 }, 1)]
    [TestCase(1, new[] { 2 }, 2)]
    [TestCase(1, new[] { 2 }, 3)]
    [TestCase(1, new[] { 2 }, 4)]
    [TestCase(1, new[] { 2 }, 5)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(null, new int[0], 2)]
    [TestCase(null, new int[0], 3)]
    [TestCase(null, new int[0], 4)]
    [TestCase(null, new int[0], 5)]
    public async Task MapAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .MapAsync(x => ++x)
                .Then(x => x.AsEnumerable()),
            2 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .MapAsync(x => Task.FromResult(++x))
                .Then(x => x.AsEnumerable()),
            3 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .MapAsync(x => Task.FromResult(++x))
                .Then(x => x.AsEnumerable()),
            4 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .MapAsync(x => ++x)
                .Then(x => x.AsEnumerable()),
            5 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .MapAsync(x => Task.FromResult(++x))
                .Then(x => x.AsEnumerable()),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .MapAsync(x => Task.FromResult(++x))
                .Then(x => x.AsEnumerable())
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task MapAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.MapAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MapAsync(_ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.MapAsync(_ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.MapAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MapAsync(_ => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.MapAsync(_ => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task MapAsyncMapperCanceled()
    {
        var result = Result.Ok(0);
        var resultTask = ResultTask.Ok(0);
        var result2 = Result.Ok<int, int>(0);
        var result2Task = ResultTask.Ok<int, int>(0);
        using (var cts = new CancellationTokenSource())
            await result
                .Awaiting(x => x.MapAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await resultTask
                .Awaiting(x => x.MapAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await result2
                .Awaiting(x => x.MapAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await result2Task
                .Awaiting(x => x.MapAsync(y =>
                {
                    cts.Cancel();
                    return Task.FromResult(y);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
    }
}
