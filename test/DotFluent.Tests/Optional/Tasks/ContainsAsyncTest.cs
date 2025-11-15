using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionContainsAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.ContainsAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ValueFactoryNullThrowsException()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        Func<Task<int>> valueFactory = null;

        await option
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ValueFactoryReturningNullThrowsException()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);

        await option
            .Awaiting(x => x.ContainsAsync(() => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.ContainsAsync(() => null))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, 1, false, 0)]
    [TestCase(null, 1, false, 1)]
    [TestCase(null, 1, false, 2)]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(1, 2, false, 2)]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 1, true, 1)]
    [TestCase(1, 1, true, 2)]
    public async Task ContainsAsync(int? source, int value, bool expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .ToOptionAsync()
                .ContainsAsync(value),
            2 => await source
                .ToOptionAsync()
                .ContainsAsync(() => Task.FromResult(value)),
            _ => await source
                .ToOption()
                .ContainsAsync(() => Task.FromResult(value))
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ContainsAsyncCanceled()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.ContainsAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task ContainsAsyncValueFactoryCanceled()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);
        using (var cts = new CancellationTokenSource())
            await option
                .Awaiting(x => x.ContainsAsync(() =>
                {
                    cts.Cancel();
                    return Task.FromResult(0);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await optionTask
                .Awaiting(x => x.ContainsAsync(() =>
                {
                    cts.Cancel();
                    return Task.FromResult(0);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultContainsAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.ContainsAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.ContainsAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ValueFactoryNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        Func<Task<int>> valueFactory = null;

        await result
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ValueFactoryReturningNullThrowsException()
    {
        var result = Result.Ok(0);
        var resultTask = ResultTask.Ok(0);
        var result2 = Result.Ok<int, int>(0);
        var result2Task = ResultTask.Ok<int, int>(0);

        await result
            .Awaiting(x => x.ContainsAsync(() => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.ContainsAsync(() => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.ContainsAsync(() => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.ContainsAsync(() => null))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 1, true, 1)]
    [TestCase(1, 1, true, 2)]
    [TestCase(1, 1, true, 3)]
    [TestCase(1, 1, true, 4)]
    [TestCase(1, 1, true, 5)]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(1, 2, false, 2)]
    [TestCase(1, 2, false, 3)]
    [TestCase(1, 2, false, 4)]
    [TestCase(1, 2, false, 5)]
    [TestCase(null, 1, false, 0)]
    [TestCase(null, 1, false, 1)]
    [TestCase(null, 1, false, 2)]
    [TestCase(null, 1, false, 3)]
    [TestCase(null, 1, false, 4)]
    [TestCase(null, 1, false, 5)]
    public async Task ContainsAsync(int? source, int value, bool expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ContainsAsync(value),
            2 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ContainsAsync(() => Task.FromResult(value)),
            3 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .ContainsAsync(() => Task.FromResult(value)),
            4 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ContainsAsync(value),
            5 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ContainsAsync(() => Task.FromResult(value)),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .ContainsAsync(() => Task.FromResult(value))
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ContainsAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.ContainsAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.ContainsAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task ContainsAsyncValueFactoryCanceled()
    {
        var result = Result.Ok(0);
        var resultTask = ResultTask.Ok(0);
        var result2 = Result.Ok<int, int>(0);
        var result2Task = ResultTask.Ok<int, int>(0);
        using (var cts = new CancellationTokenSource())
            await result
                .Awaiting(x => x.ContainsAsync(() =>
                {
                    cts.Cancel();
                    return Task.FromResult(0);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await resultTask
                .Awaiting(x => x.ContainsAsync(() =>
                {
                    cts.Cancel();
                    return Task.FromResult(0);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await result2
                .Awaiting(x => x.ContainsAsync(() =>
                {
                    cts.Cancel();
                    return Task.FromResult(0);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await result2Task
                .Awaiting(x => x.ContainsAsync(() =>
                {
                    cts.Cancel();
                    return Task.FromResult(0);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
    }
}
