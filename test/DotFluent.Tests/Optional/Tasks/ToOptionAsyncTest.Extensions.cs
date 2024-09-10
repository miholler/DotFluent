using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionToOptionAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<string> nullableTask = null;
        Task<int?> nullableValueTask = null;
        Task<Result<int>> nullableResultTask = null;
        Task<Result<int, int>> nullableResult2Task = null;

        await nullableTask
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await nullableValueTask
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await nullableResultTask
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await nullableResult2Task
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new string[0])]
    [TestCase("ABC", new[] { "ABC" })]
    public async Task ReferenceTypeToOptionAsync(string source, IEnumerable<string> expectedResult)
    {
        var result = await Task
            .FromResult(source)
            .ToOptionAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public async Task ValueTypeToOptionAsync(int? source, IEnumerable<int> expectedResult)
    {
        var result = await Task
            .FromResult(source)
            .ToOptionAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    public async Task ResultToOptionAsync(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .Match(ResultTask.Ok<int, int>, () => ResultTask.Error<int, int>(0))
                .ToOptionAsync(),
            _ => await source
                .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
                .ToOptionAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ToOptionAsyncCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await Task.FromResult(string.Empty)
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task.FromResult(new int?())
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await ResultTask.Error<int>(new())
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await ResultTask.Error<int, int>(0)
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
