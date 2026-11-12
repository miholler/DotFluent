using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableToListAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ToListAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    public async Task ToListAsync(IEnumerable<int> source, IEnumerable<int> expectedResult)
    {
        var result = await source
            .ToAsyncEnumerable()
            .ToListAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ToListAsyncCanceled()
    {
        var source = AsyncEnumerable
            .Create(0)
            .AsAsyncIterator();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ToListAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
