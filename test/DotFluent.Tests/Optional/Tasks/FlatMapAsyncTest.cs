using DotFluent.Tasks;
using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFlatMapAsyncTest
{
    #region Methods

    [Test]
    public async Task MapperNullThrowsException()
    {
        var option = Option.None<int>();
        Func<int, Task<Option<int>>> mapper = null;

        await option
            .Awaiting(x => x.FlatMapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var option = Option.Some(0);

        await option
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Option<int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public async Task FlatMapAsync(int? source, IEnumerable<int> expectedResult)
    {
        var result = await source
            .ToOption()
            .FlatMapAsync(OptionTask.Some);

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlatMapAsyncCanceled()
    {
        var option = Option.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.FlatMapAsync(OptionTask.Some, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultFlatMapAsyncTest
{
    #region Methods

    [Test]
    public async Task MapperNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        Func<int, Task<Result<int>>> mapper = null;
        Func<int, Task<Result<int, int>>> mapper2 = null;

        await result
            .Awaiting(x => x.FlatMapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.FlatMapAsync(mapper2))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var result = Result.Ok(0);
        var result2 = Result.Ok<int, int>(0);

        await result
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Result<int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Result<int, int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    public async Task FlatMapAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .FlatMapAsync(ResultTask.Ok<int, int>)
                .Then(y => y.AsEnumerable()),
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
        var result2 = Result.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.FlatMapAsync(ResultTask.Ok, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.FlatMapAsync(ResultTask.Ok<int, int>, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
