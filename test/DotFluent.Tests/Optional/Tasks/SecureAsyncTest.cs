using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionSecureAsyncTest
{
    [Test]
    public async Task SecureAsync()
    {
        var result = await Option
            .Some<object>(null)
            .SecureAsync();

        result.ShouldBe(Option<object>.None);
    }

    [Test]
    public async Task SecureAsyncCanceled()
    {
        var option = Option.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
