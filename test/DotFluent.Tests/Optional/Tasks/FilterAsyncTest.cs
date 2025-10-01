using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionFilterAsyncTest
{
    [Test]
    public async Task PredicateNullThrowsException()
    {
        var option = Option.None<int>();
        Func<int, Task<bool>> predicate = null;

        await option
            .Awaiting(x => x.FilterAsync(predicate))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task PredicateReturningNullThrowsException()
    {
        var option = Option.Some(0);

        await option
            .Awaiting(x => x.FilterAsync(_ => null))
            .ShouldThrowAsync<InvalidOperationException>();
    }

    [Test]
    [TestCase(null, 1, new int[0])]
    [TestCase(1, 2, new int[0])]
    [TestCase(1, 1, new[] { 1 })]
    public async Task FilterAsync(int? source, int value, IEnumerable<int> expectedResult)
    {
        var result = await source
            .ToOption()
            .FilterAsync(x => Task.FromResult(x == value));

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task FilterAsyncCanceled()
    {
        var option = Option.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.FilterAsync(_ => Task.FromResult(false), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task FilterAsyncPredicateCanceled()
    {
        var option = Option.Some(0);
        using var cts = new CancellationTokenSource();

        await option
            .Awaiting(x => x.FilterAsync(_ =>
            {
                cts.Cancel();
                return Task.FromResult(false);
            }, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
