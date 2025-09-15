using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionContainsAsyncTest
{
    #region Methods

    [Test]
    public async Task ValueFactoryNullThrowsException()
    {
        var option = Option.None<int>();
        Func<Task<int>> valueFactory = null;

        await option
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ValueFactoryReturningNullThrowsException()
    {
        var option = Option.Some(0);

        await option
            .Awaiting(x => x.ContainsAsync(() => null))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(1, 1, true)]
    public async Task ContainsAsync(int? source, int value, bool expectedResult)
    {
        var result = await source
            .ToOption()
            .ContainsAsync(() => Task.FromResult(value));

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ContainsAsyncCanceled()
    {
        var option = Option.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task ContainsAsyncValueFactoryCanceled()
    {
        var option = Option.Some(0);
        using var cts = new CancellationTokenSource();

        await option
            .Awaiting(x => x.ContainsAsync(() =>
            {
                cts.Cancel();
                return Task.FromResult(0);
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultContainsAsyncTest
{
    #region Methods

    [Test]
    public async Task ValueFactoryNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        Func<Task<int>> valueFactory = null;

        await result
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ValueFactoryReturningNullThrowsException()
    {
        var result = Result.Ok(0);
        var result2 = Result.Ok<int, int>(0);

        await result
            .Awaiting(x => x.ContainsAsync(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.ContainsAsync(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 1, true, 0)]
    [TestCase(1, 1, true, 1)]
    [TestCase(1, 2, false, 0)]
    [TestCase(1, 2, false, 1)]
    [TestCase(null, 1, false, 0)]
    [TestCase(null, 1, false, 1)]
    public async Task ContainsAsync(int? source, int value, bool expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
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
        var result2 = Result.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task ContainsAsyncValueFactoryCanceled()
    {
        var result = Result.Ok(0);
        var result2 = Result.Ok<int, int>(0);
        using (var cts = new CancellationTokenSource())
            await result
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
    }

    #endregion
}
