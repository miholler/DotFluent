using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionToOptionAsyncTest
{
    #region Methods

    [Test]
    [TestCase(null, new string[0])]
    [TestCase("ABC", new[] { "ABC" })]
    public async Task ReferenceTypeToOptionAsync(string source, IEnumerable<string> expectedResult)
    {
        var result = await source.ToOptionAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public async Task ValueTypeToOptionAsync(int? source, IEnumerable<int> expectedResult)
    {
        var result = await source.ToOptionAsync();

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
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .ToOptionAsync(),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .ToOptionAsync()
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ToOptionAsyncCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await string.Empty
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await new int?()
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Result.Error<int>(new())
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Result.Error<int, int>(0)
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
