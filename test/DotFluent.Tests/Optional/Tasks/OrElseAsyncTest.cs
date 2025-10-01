using DotFluent.Tasks;
using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionOrElseAsyncTest
{
    [Test]
    public async Task OtherFactoryNullThrowsException()
    {
        var option = Option.None<int>();
        Func<Task<Option<int>>> otherFactory = null;

        await option
            .Awaiting(x => x.OrElseAsync(otherFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OtherFactoryReturningNullThrowsException()
    {
        var option = Option.None<int>();

        await option
            .Awaiting(x => x.OrElseAsync(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, null, new int[0])]
    [TestCase(1, null, new[] { 1 })]
    [TestCase(null, 1, new[] { 1 })]
    [TestCase(1, 2, new[] { 1 })]
    public async Task OrElseAsync(int? source, int? other, IEnumerable<int> expectedResult)
    {
        var result = await source
            .ToOption()
            .OrElseAsync(() => other.ToOptionAsync());

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task OrElseAsyncCanceled()
    {
        var option = Option.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .OrElseAsync(OptionTask.None<int>, cts.Token)
            .ShouldThrowAsync<TaskCanceledException>();
    }
}

[TestFixture]
public sealed class ResultOrElseAsyncTest
{
    [Test]
    public async Task OtherFactoryNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        Func<Task<Result<int>>> otherFactory = null;
        Func<Task<Result<int, int>>> otherFactory2 = null;

        await result
            .Awaiting(x => x.OrElseAsync(otherFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await result2
            .Awaiting(x => x.OrElseAsync(otherFactory2))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OtherFactoryReturningNullThrowsException()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);

        await result
            .Awaiting(x => x.OrElseAsync(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
        await result2
            .Awaiting(x => x.OrElseAsync(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 2, new[] { 1 }, 0)]
    [TestCase(1, 2, new[] { 1 }, 1)]
    [TestCase(1, null, new[] { 1 }, 0)]
    [TestCase(1, null, new[] { 1 }, 1)]
    [TestCase(null, 1, new[] { 1 }, 0)]
    [TestCase(null, 1, new[] { 1 }, 1)]
    [TestCase(null, null, new int[0], 0)]
    [TestCase(null, null, new int[0], 1)]
    public async Task OrElseAsync(int? source, int? other, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .OrElseAsync(() => other.Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0)))
                .Then(x => x.AsEnumerable()),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .OrElseAsync(() => other.Match(ResultTask.Ok, () => ResultTask.Error<int>(new())))
                .Then(x => x.AsEnumerable())
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task OrElseAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.OrElseAsync(() => ResultTask.Error<int>(new()), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.OrElseAsync(() => ResultTask.Error<int, int>(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
