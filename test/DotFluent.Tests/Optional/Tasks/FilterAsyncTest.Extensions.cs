using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFilterAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.FilterAsync(_ => false))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.FilterAsync(_ => Task.FromResult(false)))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateNullThrowsException()
    {
        var optionTask = OptionTask.None<int>();
        Func<int, bool> predicate = null;
        Func<int, Task<bool>> taskPredicate = null;

        await optionTask
            .Awaiting(x => x.FilterAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.FilterAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 1, new int[0], 0)]
    [TestCase(null, 1, new int[0], 1)]
    [TestCase(1, 2, new int[0], 0)]
    [TestCase(1, 2, new int[0], 1)]
    [TestCase(1, 1, new[] { 1 }, 0)]
    [TestCase(1, 1, new[] { 1 }, 1)]
    public async Task FilterAsync(int? source, int value, IEnumerable<int> expectedResult, int overload)
    {
        var optionTask = source.ToOptionAsync();
        var result = overload switch
        {
            1 => await optionTask.FilterAsync(x => Task.FromResult(x == value)),
            _ => await optionTask.FilterAsync(x => x == value)
        };

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FilterAsyncCanceled()
    {
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await optionTask
            .Awaiting(x => x.FilterAsync(_ => false, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.FilterAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
