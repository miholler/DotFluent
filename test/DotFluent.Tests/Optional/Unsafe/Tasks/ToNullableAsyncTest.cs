using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Unsafe.Tasks;

[TestFixture]
public sealed class OptionToNullableAsyncTest
{
    #region Methods

    [Test]
    [TestCase(null)]
    [TestCase(1)]
    public async Task ToNullableAsync(int? source)
    {
        var result = await source
            .ToOption()
            .ToNullableAsync();

        result.ShouldBe(source);
    }

    [Test]
    public async Task ToNullableAsyncCanceled()
    {
        var option = Option.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultToNullableAsyncTest
{
    #region Methods

    [Test]
    [TestCase(1, 0)]
    [TestCase(1, 1)]
    [TestCase(null, 0)]
    [TestCase(null, 1)]
    public async Task ToNullableAsync(int? source, int overload)
    {
        var currentResult = overload switch
        {
            1 => await source
                .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                .ToNullableAsync(),
            _ => await source
                .Match(Result.Ok, () => Result.Error<int>(new()))
                .ToNullableAsync()
        };

        currentResult.ShouldBe(source);
    }

    [Test]
    public async Task ToNullableAsyncCanceled()
    {
        var result = Result.Error<int>(new());
        var result2 = Result.Error<int, int>(0);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await result2
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
