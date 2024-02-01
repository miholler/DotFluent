using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionOrElseAsyncTest
{
    #region Methods

    [Test]
    public async Task OtherFactoryNullThrowsException()
    {
        var option = await OptionTask.None<int>();
        Func<Task<Option<int>>> otherFactory = null;

        await option
            .Awaiting(x => x.OrElseAsync(otherFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OtherFactoryReturningNullThrowsException()
    {
        var option = await OptionTask.None<int>();

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
        var option = await source.ToOptionAsync();
        var result = await option.OrElseAsync(() => other.ToOptionAsync());

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task OrElseAsyncCanceled()
    {
        var option = await OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .OrElseAsync(OptionTask.None<int>, cts.Token)
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultOrElseAsyncTest
{
    #region Methods

    [Test]
    public async Task OtherFactoryNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());
        Func<Task<Result<int>>> otherFactory = null;

        await result
            .Awaiting(x => x.OrElseAsync(otherFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OtherFactoryReturningNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());

        await result
            .Awaiting(x => x.OrElseAsync(() => default))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, 2, new[] { 1 })]
    [TestCase(1, null, new[] { 1 })]
    [TestCase(null, 1, new[] { 1 })]
    [TestCase(null, null, new int[0])]
    public async Task OrElseAsync(int? source, int? other, IEnumerable<int> expectedResult)
    {
        var result = await source.Match(ResultTask.Ok, () => ResultTask.Error<int>(new()));
        var currentResult = await result.OrElseAsync(() => other.Match(ResultTask.Ok, () => ResultTask.Error<int>(new())));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task OrElseAsyncCanceled()
    {
        var result = await ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.OrElseAsync(() => ResultTask.Error<int>(new()), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
