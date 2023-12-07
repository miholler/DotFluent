using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFlatMapAsyncTest
{
    #region Methods

    [Test]
    public async Task MapperNullThrowsException()
    {
        var option = await OptionTask.None<int>();
        Func<int, Task<Option<int>>> mapper = null;

        await option
            .Awaiting(x => x.FlatMapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var option = await OptionTask.Some(0);

        await option
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Option<int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public async Task FlatMapAsync(int? source, IEnumerable<int> expectedResult)
    {
        var option = await source.ToOptionAsync();
        var result = await option.FlatMapAsync(x => OptionTask.Some(x));

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlatMapAsyncCanceled()
    {
        var option = await OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.FlatMapAsync(y => OptionTask.Some(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultFlatMapAsyncTest
{
    #region Methods

    [Test]
    public async Task MapperNullThrowsException()
    {
        var result = await ResultTask.Error<int>(new());
        Func<int, Task<Result<int>>> mapper = null;

        await result
            .Awaiting(x => x.FlatMapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var result = await ResultTask.Ok(0);

        await result
            .Awaiting(x => x.FlatMapAsync(_ => default(Task<Result<int>>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, new[] { 1 })]
    [TestCase(null, new int[0])]
    public async Task FlatMapAsync(int? source, IEnumerable<int> expectedResult)
    {
        var result = await source.Match(ResultTask.Ok, () => ResultTask.Error<int>(new()));
        var currentResult = await result.FlatMapAsync(x => ResultTask.Ok(x));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlatMapAsyncCanceled()
    {
        var result = await ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.FlatMapAsync(y => ResultTask.Ok(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
