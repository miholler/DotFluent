using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionGetValueOrDefaultAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        Func<int> valueFactory = null;
        Func<Task<int>> taskValueFactory = null;

        await option
            .Awaiting(x => x.GetValueOrDefaultAsync(taskValueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(taskValueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, 1, 0)]
    [TestCase(null, 0, 0, 1)]
    [TestCase(null, 1, 1, 2)]
    [TestCase(null, 1, 1, 3)]
    [TestCase(null, 1, 1, 4)]
    [TestCase(1, 2, 1, 0)]
    [TestCase(1, 2, 1, 1)]
    [TestCase(1, 2, 1, 2)]
    [TestCase(1, 2, 1, 3)]
    [TestCase(1, 2, 1, 4)]
    public async Task GetValueOrDefaultAsync(int? source, int defaultValue, int expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .ToOptionAsync()
                .GetValueOrDefaultAsync(),
            2 => await source
                .ToOptionAsync()
                .GetValueOrDefaultAsync(defaultValue),
            3 => await source
                .ToOptionAsync()
                .GetValueOrDefaultAsync(() => defaultValue),
            4 => await source
                .ToOptionAsync()
                .GetValueOrDefaultAsync(() => Task.FromResult(defaultValue)),
            _ => await source
                .ToOption()
                .GetValueOrDefaultAsync(() => Task.FromResult(defaultValue))
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task GetValueOrDefaultAsyncCanceled()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultGetValueOrDefaultAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        Func<int> valueFactory = null;
        Func<Task<int>> taskValueFactory = null;

        await result
            .Awaiting(x => x.GetValueOrDefaultAsync(taskValueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(taskValueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.GetValueOrDefaultAsync(taskValueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(taskValueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, 1, 0)]
    [TestCase(1, 2, 1, 1)]
    [TestCase(1, 2, 1, 2)]
    [TestCase(1, 2, 1, 3)]
    [TestCase(1, 2, 1, 4)]
    [TestCase(1, 2, 1, 5)]
    [TestCase(1, 2, 1, 6)]
    [TestCase(1, 2, 1, 7)]
    [TestCase(1, 2, 1, 8)]
    [TestCase(1, 2, 1, 9)]
    [TestCase(null, 1, 1, 0)]
    [TestCase(null, 0, 0, 1)]
    [TestCase(null, 1, 1, 2)]
    [TestCase(null, 1, 1, 3)]
    [TestCase(null, 1, 1, 4)]
    [TestCase(null, 1, 1, 5)]
    [TestCase(null, 0, 0, 6)]
    [TestCase(null, 1, 1, 7)]
    [TestCase(null, 1, 1, 8)]
    [TestCase(null, 1, 1, 9)]
    public async Task GetValueOrDefaultAsync(int? source, int defaultValue, int expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .GetValueOrDefaultAsync(),
            2 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .GetValueOrDefaultAsync(defaultValue),
            3 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .GetValueOrDefaultAsync(() => defaultValue),
            4 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .GetValueOrDefaultAsync(() => Task.FromResult(defaultValue)),
            5 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .GetValueOrDefaultAsync(() => Task.FromResult(defaultValue)),
            6 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .GetValueOrDefaultAsync(),
            7 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .GetValueOrDefaultAsync(defaultValue),
            8 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .GetValueOrDefaultAsync(() => defaultValue),
            9 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .GetValueOrDefaultAsync(() => Task.FromResult(defaultValue)),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .GetValueOrDefaultAsync(() => Task.FromResult(defaultValue))
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task GetValueOrDefaultAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(() => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
