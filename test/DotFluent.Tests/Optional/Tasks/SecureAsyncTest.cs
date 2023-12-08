using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionSecureAsyncTest
{
    #region Methods

    [Test]
    public async Task SecureAsync()
    {
        var option = await OptionTask.Some<object>(null);
        var result = await option.SecureAsync();

        result.ShouldBe(Option<object>.None);
    }

    [Test]
    public async Task SecureAsyncCanceled()
    {
        var option = await OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
