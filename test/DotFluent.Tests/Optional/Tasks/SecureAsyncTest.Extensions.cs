using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class SecureAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.SecureAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SecureAsync()
    {
        var optionTask = OptionTask.Some<object>(null);
        var result = await optionTask.SecureAsync();

        result.ShouldBe(Option<object>.None);
    }

    [Test]
    public async Task SecureAsyncCanceled()
    {
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await optionTask
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
