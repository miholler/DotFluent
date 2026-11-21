using DotFluent.Tasks;
using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFlattenAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<Option<int>>> optionTask = null;

        await optionTask
            .Awaiting(x => x.FlattenAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await OptionTask
                .Some(source.ToOption())
                .FlattenAsync(),
            _ => await Option
                .Some(source.ToOption())
                .FlattenAsync()
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlattenAsyncCanceled()
    {
        var option = Option.None<Option<int>>();
        var optionTask = OptionTask.None<Option<int>>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultFlattenAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<Result<int>>> resultTask = null;
        Task<Result<Result<int, int>, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.FlattenAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.FlattenAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(1, new[] { 1 }, 2)]
    [TestCase(1, new[] { 1 }, 3)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(null, new int[0], 2)]
    [TestCase(null, new int[0], 3)]
    public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await ResultTask
                .Ok(source.Match(Result.Ok, () => Result.Error<int>(new())))
                .FlattenAsync()
                .Then(x => x.AsEnumerable()),
            2 => await Result
                .Ok<Result<int, int>, int>(source.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0)))
                .FlattenAsync()
                .Then(x => x.AsEnumerable()),
            3 => await ResultTask
                .Ok<Result<int, int>, int>(source.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0)))
                .FlattenAsync()
                .Then(x => x.AsEnumerable()),
            _ => await Result
                .Ok(source.Match(Result.Ok, () => Result.Error<int>(new())))
                .FlattenAsync()
                .Then(x => x.AsEnumerable())
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlattenAsyncCanceled()
    {
        var result = Result.Error<Result<int>>(new());
        var resultTask = ResultTask.Error<Result<int>>(new());
        var result2 = Result.Error<Result<int, int>, int>(0);
        var result2Task = ResultTask.Error<Result<int, int>, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
