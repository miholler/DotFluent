using DotFluent.Tasks;
using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFlatMapAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.FlatMapAsync(_ => Option.None<int>()))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.FlatMapAsync(_ => OptionTask.None<int>()))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperNullThrowsException()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        Func<int, Option<int>> mapper = null;
        Func<int, Task<Option<int>>> taskMapper = null;

        await option
            .Awaiting(x => x.FlatMapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.FlatMapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.FlatMapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);

        await option
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Option<int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Option<int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(null, new int[0], 2)]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(1, new[] { 1 }, 2)]
    public async Task FlatMapAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .ToOptionAsync()
                .FlatMapAsync(Option.Some),
            2 => await source
                .ToOptionAsync()
                .FlatMapAsync(OptionTask.Some),
            _ => await source
                .ToOption()
                .FlatMapAsync(OptionTask.Some)
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlatMapAsyncCanceled()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.FlatMapAsync(OptionTask.Some, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.FlatMapAsync(_ => Option.None<int>(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.FlatMapAsync(_ => OptionTask.None<int>(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultFlatMapAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.FlatMapAsync(_ => Result.Error<int>(new())))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.FlatMapAsync(_ => ResultTask.Error<int>(new())))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.FlatMapAsync(Result.Error<int, int>))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.FlatMapAsync(ResultTask.Error<int, int>))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        Func<int, Result<int>> mapper = null;
        Func<int, Result<int, int>> mapper2 = null;
        Func<int, Task<Result<int>>> taskMapper = null;
        Func<int, Task<Result<int, int>>> taskMapper2 = null;

        await result
            .Awaiting(x => x.FlatMapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.FlatMapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.FlatMapAsync(taskMapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.FlatMapAsync(taskMapper2))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.FlatMapAsync(mapper2))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.FlatMapAsync(taskMapper2))
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
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Result<int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Result<int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Result<int, int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Result<int, int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(1, new[] { 1 }, 2)]
    [TestCase(1, new[] { 1 }, 3)]
    [TestCase(1, new[] { 1 }, 4)]
    [TestCase(1, new[] { 1 }, 5)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(null, new int[0], 2)]
    [TestCase(null, new int[0], 3)]
    [TestCase(null, new int[0], 4)]
    [TestCase(null, new int[0], 5)]
    public async Task FlatMapAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .FlatMapAsync(Result.Ok)
                .Then(x => x.AsEnumerable()),
            2 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .FlatMapAsync(ResultTask.Ok)
                .Then(x => x.AsEnumerable()),
            3 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .FlatMapAsync(ResultTask.Ok<int, int>)
                .Then(y => y.AsEnumerable()),
            4 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .FlatMapAsync(Result.Ok<int, int>)
                .Then(x => x.AsEnumerable()),
            5 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .FlatMapAsync(ResultTask.Ok<int, int>)
                .Then(x => x.AsEnumerable()),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .FlatMapAsync(ResultTask.Ok)
                .Then(y => y.AsEnumerable())
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlatMapAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.FlatMapAsync(ResultTask.Ok, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.FlatMapAsync(_ => Result.Error<int>(new()), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.FlatMapAsync(_ => ResultTask.Error<int>(new()), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.FlatMapAsync(ResultTask.Ok<int, int>, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.FlatMapAsync(Result.Error<int, int>, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.FlatMapAsync(ResultTask.Error<int, int>, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
