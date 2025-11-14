using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionToOptionAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<string> nullableTask = null;
        Task<int?> nullableValueTask = null;
        Task<Result<int>> nullableResultTask = null;
        Task<Result<int, int>> nullableResult2Task = null;

        await nullableTask
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await nullableValueTask
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await nullableResultTask
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await nullableResult2Task
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new string[0], 0)]
    [TestCase(null, new string[0], 1)]
    [TestCase("ABC", new[] { "ABC" }, 0)]
    [TestCase("ABC", new[] { "ABC" }, 1)]
    public async Task ReferenceTypeToOptionAsync(string source, IEnumerable<string> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await Task
                .FromResult(source)
                .ToOptionAsync(),
            _ => await source.ToOptionAsync()
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    public async Task ValueTypeToOptionAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await Task
                .FromResult(source)
                .ToOptionAsync(),
            _ => await source.ToOptionAsync()
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(null, new int[0], 2)]
    [TestCase(null, new int[0], 3)]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(1, new[] { 1 }, 2)]
    [TestCase(1, new[] { 1 }, 3)]
    public async Task ResultToOptionAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ToOptionAsync(),
            2 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .ToOptionAsync(),
            3 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ToOptionAsync(),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .ToOptionAsync()
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ToOptionAsyncCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await string.Empty
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await new int?()
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Result.Error<int>(new())
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Result.Error<int, int>(0)
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task.FromResult(string.Empty)
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task.FromResult(new int?())
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await ResultTask.Error<int>(new())
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await ResultTask.Error<int, int>(0)
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
