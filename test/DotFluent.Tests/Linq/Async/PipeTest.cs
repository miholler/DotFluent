using NUnit.Framework;
using Shouldly;
using System.Text;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerablePipeTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;

        source
            .Invoking(x => x.Pipe(y => y++))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe((y, i) => y += i))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe((y, ct) => ValueTask.CompletedTask))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe((y, i, ct) => ValueTask.CompletedTask))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ActionNullThrowsException()
    {
        var source = AsyncEnumerable.Empty<int>();
        Action<int> action = null;
        Action<int, int> indexAction = null;
        Func<int, CancellationToken, ValueTask> taskAction = null;
        Func<int, int, CancellationToken, ValueTask> taskIndexAction = null;

        source
            .Invoking(x => x.Pipe(action))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe(indexAction))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe(taskAction))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe(taskIndexAction))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new string[0], new string[0], 0)]
    [TestCase(new string[0], new string[0], 1)]
    [TestCase(new string[0], new string[0], 2)]
    [TestCase(new string[0], new string[0], 3)]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A#", "B#", "C#" }, 0)]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A0", "B1", "C2" }, 1)]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A#", "B#", "C#" }, 2)]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A0", "B1", "C2" }, 3)]
    public async Task Pipe(IEnumerable<string> source, IEnumerable<string> expectedResult, int overload)
    {
        var result = source
            .Select(x => new StringBuilder(x))
            .ToAsyncEnumerable();
        result = overload switch
        {
            1 => result.Pipe((x, i) => x.Append(i)),
            2 => result.Pipe((x, ct) =>
            {
                x.Append('#');
                return ValueTask.CompletedTask;
            }),
            3 => result.Pipe((x, i, ct) =>
            {
                x.Append(i);
                return ValueTask.CompletedTask;
            }),
            _ => result.Pipe(x => x.Append('#'))
        };
        (await result.ToArrayAsync())
            .Select(x => x.ToString())
            .ShouldBe(expectedResult);
    }

    [Test]
    public async Task PipeCanceled()
    {
        var source = AsyncEnumerable
            .Create(0)
            .AsAsyncIterator();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x
                .Pipe(y => y++)
                .ToArrayAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x
                .Pipe((y, i) => y += i)
                .ToArrayAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x
                .Pipe((y, ct) => ValueTask.CompletedTask)
                .ToArrayAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x
                .Pipe((y, i, ct) => ValueTask.CompletedTask)
                .ToArrayAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
