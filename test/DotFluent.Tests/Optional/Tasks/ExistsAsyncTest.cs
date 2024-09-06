using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionExistsAsyncTest
{
    #region Methods

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var option = await OptionTask.None<int>();
        Func<int, Task<bool>> predicate = null;

        await option
            .Awaiting(x => x.ExistsAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateReturningNullThrowsException()
    {
        var option = await OptionTask.Some(0);

        await option
            .Awaiting(x => x.ExistsAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(1, 1, true)]
    public async Task ExistsAsync(int? source, int value, bool expectedResult)
    {
        var option = await source.ToOptionAsync();
        var result = await option.ExistsAsync(x => Task.FromResult(x == value));

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ExistsAsyncCanceled()
    {
        var option = await OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultExistsAsyncTest
{
    #region Methods

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());
        var result2 = await ResultTask.Error<int, int>(0);
        Func<int, Task<bool>> predicate = null;

        await result
            .Awaiting(x => x.ExistsAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.ExistsAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateReturningNullThrowsException()
    {
        var result = await ResultTask.Ok(0);
        var result2 = await ResultTask.Ok<int, int>(0);

        await result
            .Awaiting(x => x.ExistsAsync(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.ExistsAsync(_ => default))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 1, true, 1)]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(null, 1, false, 0)]
    [TestCase(null, 1, false, 1)]
    public async Task ExistsAsync(int? source, int value, bool expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ExistsAsync(x => Task.FromResult(x == value)),
            _ => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ExistsAsync(x => Task.FromResult(x == value))
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ExistsAsyncCanceled()
    {
        var result = await ResultTask.Error<int>(new());
        var result2 = await ResultTask.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
