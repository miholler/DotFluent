using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableForEachAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        await source
            .Awaiting(x => x.ForEachAsync(y => y++))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, i) => y += i))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, ct) => ValueTask.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, i, ct) => ValueTask.CompletedTask))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ActionNullThrowsException()
    {
        var source = AsyncEnumerable.Empty<int>();
        Action<int> action = null;
        Action<int, int> indexAction = null;
        Func<int, CancellationToken, ValueTask> taskAction = null;
        Func<int, int, CancellationToken, ValueTask> taskIndexAction = null;

        await source
            .Awaiting(x => x.ForEachAsync(action))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync(indexAction))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync(taskAction))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ForEachAsync(taskIndexAction))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], 0, 0)]
    [TestCase(new int[0], 0, 1)]
    [TestCase(new int[0], 0, 2)]
    [TestCase(new int[0], 0, 3)]
    [TestCase(new[] { 1, 2, 3 }, 6, 0)]
    [TestCase(new[] { 1, 2, 3 }, 9, 1)]
    [TestCase(new[] { 1, 2, 3 }, 6, 2)]
    [TestCase(new[] { 1, 2, 3 }, 9, 3)]
    public async Task ForEachAsync(IEnumerable<int> source, int expectedResult, int overload)
    {
        var result = 0;
        switch (overload)
        {
            case 1:
                await source
                    .ToAsyncEnumerable()
                    .ForEachAsync((x, i) => result += x + i);
                break;
            case 2:
                await source
                    .ToAsyncEnumerable()
                    .ForEachAsync((x, ct) =>
                    {
                        result += x;
                        return ValueTask.CompletedTask;
                    });
                break;
            case 3:
                await source
                    .ToAsyncEnumerable()
                    .ForEachAsync((x, i, ct) =>
                    {
                        result += x + i;
                        return ValueTask.CompletedTask;
                    });
                break;
            default:
                await source
                    .ToAsyncEnumerable()
                    .ForEachAsync(x => result += x);
                break;
        }
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ForEachAsyncCanceled()
    {
        var source = AsyncEnumerable
            .Create(0)
            .AsAsyncIterator();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ForEachAsync(y => y++, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, i) => y += i, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, ct) => ValueTask.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ForEachAsync((y, i, ct) => ValueTask.CompletedTask, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
