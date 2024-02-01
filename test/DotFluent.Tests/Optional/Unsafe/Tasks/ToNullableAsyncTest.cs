using DotFluent.Optional.Tasks;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

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
        var option = await OptionTask.None<int>();
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
    [TestCase(1)]
    [TestCase(null)]
    public async Task ToNullableAsync(int? source)
    {
        var currentResult = await source
            .Match(Result.Ok, () => Result.Error<int>(new()))
            .ToNullableAsync();

        currentResult.ShouldBe(source);
    }

    [Test]
    public async Task ToNullableAsyncCanceled()
    {
        var result = await ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await result
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
