using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionToNullableAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.ToNullableAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 0)]
    [TestCase(null, 1)]
    [TestCase(1, 0)]
    [TestCase(1, 1)]
    public async Task ToNullableAsync(int? source, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .ToOptionAsync()
                .ToNullableAsync(),
            _ => await source
                .ToOption()
                .ToNullableAsync()
        };
        result.ShouldBe(source);
    }

    [Test]
    public async Task ToNullableAsyncCanceled()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultToNullableAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.ToNullableAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.ToNullableAsync())
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
    public async Task ToNullableAsync(int? source, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ToNullableAsync(),
            2 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .ToNullableAsync(),
            3 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ToNullableAsync(),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .ToNullableAsync()
        };
        currentResult.ShouldBe(source);
    }

    [Test]
    public async Task ToNullableAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
