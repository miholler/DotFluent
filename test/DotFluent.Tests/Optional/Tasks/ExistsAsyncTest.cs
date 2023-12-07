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
        Func<int, Task<bool>> predicate = null;

        await result
            .Awaiting(x => x.ExistsAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateReturningNullThrowsException()
    {
        var result = await ResultTask.Ok(0);

        await result
            .Awaiting(x => x.ExistsAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(null, 1, false)]
    public async Task ExistsAsync(int? source, int value, bool expectedResult)
    {
        var result = await source.Match(ResultTask.Ok, () => ResultTask.Error<int>(new()));
        var currentResult = await result.ExistsAsync(x => Task.FromResult(x == value));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ExistsAsyncCanceled()
    {
        var result = await ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.ExistsAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
