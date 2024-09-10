using DotFluent.Tasks;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFlattenAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<Option<int>>> optionTask = null;

        await optionTask
            .Awaiting(x => x.FlattenAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult)
    {
        var result = await OptionTask
            .Some(source.ToOption())
            .FlattenAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlattenAsyncCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await OptionTask
            .None<Option<int>>()
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultFlattenAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<Result<int>>> resultTask = null;
        Task<Result<Result<int, int>, int>> result2Task = null;

        await resultTask
            .Awaiting(x => x.FlattenAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await result2Task
            .Awaiting(x => x.FlattenAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => await ResultTask
                .Ok<Result<int, int>, int>(source.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0)))
                .FlattenAsync()
                .Then(x => x.AsEnumerable()),
            _ => await ResultTask
                .Ok(source.Match(Result.Ok, () => Result.Error<int>(new())))
                .FlattenAsync()
                .Then(x => x.AsEnumerable())
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlattenAsyncCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await ResultTask
            .Error<Result<int>>(new())
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await ResultTask
            .Error<Result<int, int>, int>(0)
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
