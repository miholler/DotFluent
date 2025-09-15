using DotFluent.Tasks;
using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionOrElseAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.OrElseAsync(Option.None<int>()))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.OrElseAsync(Option.None<int>))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.OrElseAsync(OptionTask.None<int>))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OtherFactoryNullThrowsException()
    {
        var optionTask = OptionTask.None<int>();
        Func<Option<int>> otherFactory = null;
        Func<Task<Option<int>>> taskOtherFactory = null;

        await optionTask
            .Awaiting(x => x.OrElseAsync(otherFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.OrElseAsync(taskOtherFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, null, new int[0], 0)]
    [TestCase(null, null, new int[0], 1)]
    [TestCase(null, null, new int[0], 2)]
    [TestCase(1, null, new[] { 1 }, 0)]
    [TestCase(1, null, new[] { 1 }, 1)]
    [TestCase(1, null, new[] { 1 }, 2)]
    [TestCase(null, 1, new[] { 1 }, 0)]
    [TestCase(null, 1, new[] { 1 }, 1)]
    [TestCase(null, 1, new[] { 1 }, 2)]
    [TestCase(1, 2, new[] { 1 }, 0)]
    [TestCase(1, 2, new[] { 1 }, 1)]
    [TestCase(1, 2, new[] { 1 }, 2)]
    public async Task OrElseAsync(int? source, int? other, IEnumerable<int> expectedResult, int overload)
    {
        var optionTask = source.ToOptionAsync();
        var result = overload switch
        {
            1 => await optionTask.OrElseAsync(() => other.ToOption()),
            2 => await optionTask.OrElseAsync(() => other.ToOptionAsync()),
            _ => await optionTask.OrElseAsync(other.ToOption())
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task OrElseAsyncCanceled()
    {
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await optionTask
            .Awaiting(x => x.OrElseAsync(Option.None<int>(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.OrElseAsync(Option.None<int>, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.OrElseAsync(OptionTask.None<int>, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultOrElseAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.OrElseAsync(Result.Error<int>(new())))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.OrElseAsync(() => Result.Error<int>(new())))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.OrElseAsync(() => ResultTask.Error<int>(new())))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.OrElseAsync(Result.Error<int, int>(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.OrElseAsync(() => Result.Error<int, int>(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.OrElseAsync(() => ResultTask.Error<int, int>(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OtherFactoryNullThrowsException()
    {
        var resultTask = ResultTask.Error<int>(new());
        var result2Task = ResultTask.Error<int, int>(0);
        Func<Result<int>> otherFactory = null;
        Func<Result<int, int>> otherFactory2 = null;
        Func<Task<Result<int>>> taskOtherFactory = null;
        Func<Task<Result<int, int>>> taskOtherFactory2 = null;

        await resultTask
            .Awaiting(x => x.OrElseAsync(otherFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.OrElseAsync(taskOtherFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.OrElseAsync(otherFactory2))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.OrElseAsync(taskOtherFactory2))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, new[] { 1 }, 0)]
    [TestCase(1, 2, new[] { 1 }, 1)]
    [TestCase(1, 2, new[] { 1 }, 2)]
    [TestCase(1, 2, new[] { 1 }, 3)]
    [TestCase(1, 2, new[] { 1 }, 4)]
    [TestCase(1, 2, new[] { 1 }, 5)]
    [TestCase(1, null, new[] { 1 }, 0)]
    [TestCase(1, null, new[] { 1 }, 1)]
    [TestCase(1, null, new[] { 1 }, 2)]
    [TestCase(1, null, new[] { 1 }, 3)]
    [TestCase(1, null, new[] { 1 }, 4)]
    [TestCase(1, null, new[] { 1 }, 5)]
    [TestCase(null, 1, new[] { 1 }, 0)]
    [TestCase(null, 1, new[] { 1 }, 1)]
    [TestCase(null, 1, new[] { 1 }, 2)]
    [TestCase(null, 1, new[] { 1 }, 3)]
    [TestCase(null, 1, new[] { 1 }, 4)]
    [TestCase(null, 1, new[] { 1 }, 5)]
    [TestCase(null, null, new int[0], 0)]
    [TestCase(null, null, new int[0], 1)]
    [TestCase(null, null, new int[0], 2)]
    [TestCase(null, null, new int[0], 3)]
    [TestCase(null, null, new int[0], 4)]
    [TestCase(null, null, new int[0], 5)]
    public async Task OrElseAsync(int? source, int? other, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .OrElseAsync(() => other.Match(Result.Ok, () => Result.Error<int>(new())))
                .Then(x => x.AsEnumerable()),
            2 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .OrElseAsync(() => other.Match(ResultTask.Ok, () => ResultTask.Error<int>(new())))
                .Then(x => x.AsEnumerable()),
            3 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .OrElseAsync(other.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))),
            4 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .OrElseAsync(() => other.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))),
            5 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .OrElseAsync(() => other.Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))),
            _ => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .OrElseAsync(other.Match(Result.Ok, () => Result.Error<int>(new())))
                .Then(x => x.AsEnumerable())
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task OrElseAsyncCanceled()
    {
        var resultTask = ResultTask.Error<int>(new());
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await resultTask
            .Awaiting(x => x.OrElseAsync(Result.Error<int>(new()), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.OrElseAsync(() => Result.Error<int>(new()), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.OrElseAsync(() => ResultTask.Error<int>(new()), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.OrElseAsync(Result.Error<int, int>(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.OrElseAsync(() => Result.Error<int, int>(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.OrElseAsync(() => ResultTask.Error<int, int>(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
