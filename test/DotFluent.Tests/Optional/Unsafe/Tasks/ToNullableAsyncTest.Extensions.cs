using DotFluent.Optional.Tasks;
using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks;

[TestFixture]
public sealed class OptionToNullableAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.ToNullableAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null)]
    [TestCase(1)]
    public async Task ToNullableAsync(int? source)
    {
        var result = await source
            .ToOptionAsync()
            .ToNullableAsync();

        result.ShouldBe(source);
    }

    [Test]
    public async Task ToNullableAsyncCanceled()
    {
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await optionTask
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}

[TestFixture]
public sealed class ResultToNullableAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Result<int>> resultTask = null;

        await resultTask
            .Awaiting(x => x.ToNullableAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1)]
    [TestCase(null)]
    public async Task ToNullableAsync(int? source)
    {
        var currentResult = await source
            .Match(ResultTask.Ok, () => ResultTask.Error<int>(new()))
            .ToNullableAsync();

        currentResult.ShouldBe(source);
    }

    [Test]
    public async Task ToNullableAsyncCanceled()
    {
        var resultTask = ResultTask.Error<int>(new());
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await resultTask
            .Awaiting(x => x.ToNullableAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
