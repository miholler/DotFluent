using DotFluent.Tasks;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFlattenAsyncTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public async Task FlattenAsync(int? source, IEnumerable<int> expectedResult)
    {
        var option = await OptionTask.Some(source.ToOption());
        var result = await option.FlattenAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlattenAsyncCanceled()
    {
        var option = await OptionTask.None<Option<int>>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultFlattenAsyncTest
{
    #region Methods

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
                .Then(x => x
                    .FlattenAsync()
                    .Then(y => y.AsEnumerable())),
            _ => await ResultTask
                .Ok(source.Match(Result.Ok, () => Result.Error<int>(new())))
                .Then(x => x
                    .FlattenAsync()
                    .Then(y => y.AsEnumerable()))
        };

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FlattenAsyncCanceled()
    {
        var result = await ResultTask.Error<Result<int>>(new());
        var result2 = await ResultTask.Error<Result<int, int>, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.FlattenAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
