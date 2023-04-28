using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ContainsAsyncTest
{
    #region Methods

    [Test]
    public async Task ValueFactoryNullThrowsException()
    {
        var option = await OptionTask.None<int>();
        Func<Task<int>> valueFactory = null;

        await option
            .Awaiting(x => x.ContainsAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ValueFactoryReturningNullThrowsException()
    {
        var option = await OptionTask.None<int>();

        await option
            .Awaiting(x => x.ContainsAsync(() => null))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(1, 1, true)]
    public async Task ContainsAsync(int? source, int value, bool expectedResult)
    {
        var option = await source.ToOptionAsync();
        var result = await option.ContainsAsync(() => Task.FromResult(value));

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ContainsAsyncCanceled()
    {
        var option = await OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.ContainsAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task ContainsAsyncValueFactoryCanceled()
    {
        var option = await OptionTask.None<int>();
        using var cts = new CancellationTokenSource();

        await option
            .Awaiting(x => x.ContainsAsync(() =>
            {
                cts.Cancel();
                return Task.FromResult(0);
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
