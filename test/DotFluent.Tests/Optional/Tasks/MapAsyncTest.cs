using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionMapAsyncTest
{
    #region Methods

    [Test]
    public async Task MapperNullThrowsException()
    {
        var option = Option.None<int>();
        Func<int, Task<int>> mapper = null;

        await option
            .Awaiting(x => x.MapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var option = Option.Some(0);

        await option
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 2 })]
    public async Task MapAsync(int? source, IEnumerable<int> expectedResult)
    {
        var result = await source
            .ToOption()
            .MapAsync(x => Task.FromResult(++x));

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task MapAsyncCanceled()
    {
        var option = Option.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.MapAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task MapAsyncMappingCanceled()
    {
        var option = Option.Some(0);
        using var cts = new CancellationTokenSource();

        await option
            .Awaiting(x => x.MapAsync(y =>
            {
                cts.Cancel();
                return Task.FromResult(y);
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultMapAsyncTest
{
    #region Methods

    [Test]
    public async Task MapperNullThrowsException()
    {
        var result = Result.Error<int>(new());
        Func<int, Task<int>> mapper = null;

        await result
            .Awaiting(x => x.MapAsync(mapper))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapperReturningNullThrowsException()
    {
        var result = Result.Ok(0);

        await result
            .Awaiting(x => x.MapAsync(_ => default(Task<int>)))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(1, new[] { 2 })]
    [TestCase(null, new int[0])]
    public async Task MapAsync(int? source, IEnumerable<int> expectedResult)
    {
        var currentResult = await source
            .Match(Result.Ok, () => Result.Error<int>(new()))
            .MapAsync(x => Task.FromResult(++x));

        currentResult.ShouldBe(expectedResult);
    }

    [Test]
    public async Task MapAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.MapAsync(y => Task.FromResult(y), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task MapAsyncMappingCanceled()
    {
        var result = Result.Ok(0);
        using var cts = new CancellationTokenSource();

        await result
            .Awaiting(x => x.MapAsync(y =>
            {
                cts.Cancel();
                return Task.FromResult(y);
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
