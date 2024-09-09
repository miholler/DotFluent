using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks;

[TestFixture]
public sealed class OptionGetValueOrDefaultAsyncTest
{
    #region Methods

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var option = Option.None<int>();
        Func<Task<int>> defaultFactory = null;

        await option
            .Awaiting(x => x.GetValueOrDefaultAsync(defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, 1)]
    [TestCase(1, 2, 1)]
    public async Task GetValueOrDefaultAsync(int? source, int defaultValue, int expectedResult)
    {
        var result = await source
            .ToOption()
            .GetValueOrDefaultAsync(() => Task.FromResult(defaultValue));

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task GetValueOrDefaultAsyncCanceled()
    {
        var option = Option.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultGetValueOrDefaultAsyncTest
{
    #region Methods

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var result = Result.Error<int>(new());
        Func<Task<int>> defaultFactory = null;

        await result
            .Awaiting(x => x.GetValueOrDefaultAsync(defaultFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 2, 1)]
    [TestCase(null, 1, 1)]
    public async Task GetValueOrDefaultAsync(int? source, int defaultValue, int expectedResult)
    {
        var currentResult = await source
            .Match(Result.Ok, () => Result.Error<int>(new()))
            .GetValueOrDefaultAsync(() => Task.FromResult(defaultValue));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task GetValueOrDefaultAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
