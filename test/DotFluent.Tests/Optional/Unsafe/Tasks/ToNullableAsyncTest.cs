using DotFluent.Optional.Tasks;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks;

[TestFixture]
public sealed class ToNullableAsyncTest
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
