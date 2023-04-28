using DotFluent.Optional.Tasks;
using NUnit.Framework;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Unsafe.Tasks;

[TestFixture]
public sealed class GetValueOrDefaultAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(0))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => 0))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task DefaultFactoryNullThrowsException()
    {
        var optionTask = OptionTask.None<int>();
        Func<int> valueFactory = null;
        Func<Task<int>> taskValueFactory = null;

        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(valueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(taskValueFactory))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 0)]
    [TestCase(1, 1)]
    public async Task GetValueOrDefaultAsync(int? source, int expectedResult)
    {
        var result = await source
            .ToOptionAsync()
            .GetValueOrDefaultAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, 1, 1, 0)]
    [TestCase(1, 2, 1, 0)]
    [TestCase(null, 1, 1, 1)]
    [TestCase(1, 2, 1, 1)]
    [TestCase(null, 1, 1, 2)]
    [TestCase(1, 2, 1, 2)]
    public async Task GetValueOrDefaultAsyncWithDefaultValue(int? source, int defaultValue, int expectedResult, int overload)
    {
        var optionTask = source.ToOptionAsync();
        var result = overload switch
        {
            1 => await optionTask.GetValueOrDefaultAsync(() => defaultValue),
            2 => await optionTask.GetValueOrDefaultAsync(() => Task.FromResult(defaultValue)),
            _ => await optionTask.GetValueOrDefaultAsync(defaultValue)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task GetValueOrDefaultAsyncCanceled()
    {
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => 0, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.GetValueOrDefaultAsync(() => Task.FromResult(0), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
