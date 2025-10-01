using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionContainsAsyncExtensionsTest
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
        Func<Task<int>> valueFactory = null;

        await OptionTask
            .None<int>()
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, false, 0)]
    [TestCase(null, 1, false, 1)]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 1, true, 1)]
    public async Task ContainsAsync(int? source, int value, bool expectedResult, int overload)
    {
        var optionTask = source.ToOptionAsync();
        var result = overload switch
        {
            1 => await optionTask.ContainsAsync(() => Task.FromResult(value)),
            _ => await optionTask.ContainsAsync(value)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ContainsAsyncCanceled()
    {
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await optionTask
            .Awaiting(x => x.ContainsAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultContainsAsyncExtensionsTest
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
        Func<Task<int>> valueFactory = null;

        await ResultTask
            .Error<int>(new())
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await ResultTask
            .Error<int, int>(0)
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 1, true, 1)]
    [TestCase(1, 1, true, 2)]
    [TestCase(1, 1, true, 3)]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(1, 2, false, 2)]
    [TestCase(1, 2, false, 3)]
    [TestCase(null, 1, false, 0)]
    [TestCase(null, 1, false, 1)]
    [TestCase(null, 1, false, 2)]
    [TestCase(null, 1, false, 3)]
    public async Task ContainsAsync(int? source, int value, bool expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ContainsAsync(() => Task.FromResult(value)),
            2 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ContainsAsync(value),
            3 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ContainsAsync(() => Task.FromResult(value)),
            _ => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ContainsAsync(value)
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ContainsAsyncCanceled()
    {
        var resultTask = ResultTask.Error<int>(new());
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await resultTask
            .Awaiting(x => x.ContainsAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.ContainsAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
