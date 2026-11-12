using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableToArrayAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ToArrayAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    public async Task ToArrayAsync(IEnumerable<int> source, IEnumerable<int> expectedResult)
    {
        var result = await source
            .ToAsyncEnumerable()
            .ToArrayAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ToArrayAsyncCanceled()
    {
        var source = AsyncEnumerable
            .Create(0)
            .AsAsyncIterator();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ToArrayAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
