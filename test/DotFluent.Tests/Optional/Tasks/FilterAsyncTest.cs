using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFilterAsyncTest
{
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
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        Func<int, bool> predicate = null;
        Func<int, Task<bool>> taskPredicate = null;

        await option
            .Awaiting(x => x.FilterAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.FilterAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
        await optionTask
            .Awaiting(x => x.FilterAsync(taskPredicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateReturningNullThrowsException()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);

        await option
            .Awaiting(x => x.FilterAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
        await optionTask
            .Awaiting(x => x.FilterAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, 1, new int[0], 0)]
    [TestCase(null, 1, new int[0], 1)]
    [TestCase(null, 1, new int[0], 2)]
    [TestCase(1, 2, new int[0], 0)]
    [TestCase(1, 2, new int[0], 1)]
    [TestCase(1, 2, new int[0], 2)]
    [TestCase(1, 1, new[] { 1 }, 0)]
    [TestCase(1, 1, new[] { 1 }, 1)]
    [TestCase(1, 1, new[] { 1 }, 2)]
    public async Task FilterAsync(int? source, int value, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await source
                .ToOptionAsync()
                .FilterAsync(x => x == value),
            2 => await source
                .ToOptionAsync()
                .FilterAsync(x => Task.FromResult(x == value)),
            _ => await source
                .ToOption()
                .FilterAsync(x => Task.FromResult(x == value))
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FilterAsyncCanceled()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.FilterAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.FilterAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task FilterAsyncPredicateCanceled()
    {
        var option = Option.Some(0);
        var optionTask = OptionTask.Some(0);
        using (var cts = new CancellationTokenSource())
            await option
                .Awaiting(x => x.FilterAsync(_ =>
                {
                    cts.Cancel();
                    return Task.FromResult(false);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();

        using (var cts = new CancellationTokenSource())
            await optionTask
                .Awaiting(x => x.FilterAsync(_ =>
                {
                    cts.Cancel();
                    return Task.FromResult(false);
                }, cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
    }
}
