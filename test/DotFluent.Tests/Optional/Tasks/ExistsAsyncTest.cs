using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionExistsAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.ExistsAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        Func<int, bool> predicate = null;
        Func<int, Task<bool>> taskPredicate = null;

        await option
            .Awaiting(x => x.ExistsAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.ExistsAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.ExistsAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateReturningNullThrowsException()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);

        await option
            .Awaiting(x => x.ExistsAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.ExistsAsync(_ => null))
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
    public async Task ExistsAsync(int? source, int value, bool expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .ToOptionAsync()
                .ExistsAsync(x => x == value),
            2 => await source
                .ToOptionAsync()
                .ExistsAsync(x => Task.FromResult(x == value)),
            _ => await source
                .ToOption()
                .ExistsAsync(x => Task.FromResult(x == value))
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ExistsAsyncCanceled()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.ExistsAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultExistsAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;
        Task<Result<int, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.ExistsAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.ExistsAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        Func<int, bool> predicate = null;
        Func<int, Task<bool>> taskPredicate = null;

        await result
            .Awaiting(x => x.ExistsAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.ExistsAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await resultTask
            .Awaiting(x => x.ExistsAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.ExistsAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.ExistsAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.ExistsAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateReturningNullThrowsException()
    {
        var result = Result.Ok(0);
        var resultTask = ResultTask.Ok(0);
        var result2 = Result.Ok<int, int>(0);
        var result2Task = ResultTask.Ok<int, int>(0);

        await result
            .Awaiting(x => x.ExistsAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await resultTask
            .Awaiting(x => x.ExistsAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.ExistsAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2Task
            .Awaiting(x => x.ExistsAsync(_ => null))
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
    public async Task ExistsAsync(int? source, int value, bool expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ExistsAsync(x => x == value),
            2 => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ExistsAsync(x => Task.FromResult(x == value)),
            3 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .ExistsAsync(x => Task.FromResult(x == value)),
            4 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ExistsAsync(x => x == value),
            5 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ExistsAsync(x => Task.FromResult(x == value)),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .ExistsAsync(x => Task.FromResult(x == value))
        };
        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ExistsAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var resultTask = ResultTask.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        var result2Task = ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.ExistsAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await resultTask
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.ExistsAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2Task
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
