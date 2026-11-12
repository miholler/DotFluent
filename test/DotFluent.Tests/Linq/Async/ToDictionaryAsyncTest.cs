using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableToDictionaryAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        IAsyncEnumerable<int> source = null;
        IAsyncEnumerable<KeyValuePair<int, int>> pairSource = null;
        IAsyncEnumerable<(int Key, int Value)> tupleSource = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, ct) => ValueTask.FromResult(y)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, ct) => ValueTask.FromResult(y), (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, ct) => ValueTask.FromResult(y), (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, ct) => ValueTask.FromResult(y), EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task KeySelectorNullThrowsException()
    {
        var source = AsyncEnumerable.Empty<int>();
        Func<int, int> keySelector = null;
        Func<int, CancellationToken, ValueTask<int>> taskKeySelector = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(taskKeySelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(taskKeySelector, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(taskKeySelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(taskKeySelector, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, y => y))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(taskKeySelector, (y, ct) => new ValueTask<int>(y)))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, y => y, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(taskKeySelector, (y, ct) => new ValueTask<int>(y), (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, y => y, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(taskKeySelector, (y, ct) => new ValueTask<int>(y), (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(keySelector, y => y, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(taskKeySelector, (y, ct) => new ValueTask<int>(y), EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ElementSelectorNullThrowsException()
    {
        var source = AsyncEnumerable.Empty<int>();
        Func<int, int> elementSelector = null;
        Func<int, CancellationToken, ValueTask<int>> asyncElementSelector = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, elementSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), asyncElementSelector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, elementSelector, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), asyncElementSelector, (y, z) => y == z))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, elementSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), asyncElementSelector, (y, z) => y == z, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, elementSelector, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), asyncElementSelector, EqualityComparer<int>.Default))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ComparisonNullThrowsException()
    {
        var source = AsyncEnumerable.Empty<int>();
        var pairSource = AsyncEnumerable.Empty<KeyValuePair<int, int>>();
        var tupleSource = AsyncEnumerable.Empty<(int, int)>();
        EqualityComparison<int> comparison = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), (y, ct) => new ValueTask<int>(y), comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), (y, ct) => new ValueTask<int>(y), comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(comparison))
            .ShouldThrowAsync<ArgumentNullException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(comparison, y => y.GetHashCode()))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task HashCodeSelectorNullDoesNotThrowException()
    {
        var source = AsyncEnumerable.Empty<int>();
        var pairSource = AsyncEnumerable.Empty<KeyValuePair<int, int>>();
        var tupleSource = AsyncEnumerable.Empty<(int, int)>();
        HashFunc<int> hashCodeSelector = null;

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => new ValueTask<int>(y), (y, ct) => new ValueTask<int>(y), (y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, hashCodeSelector))
            .ShouldNotThrowAsync();
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(11)]
    [TestCase(12)]
    [TestCase(13)]
    [TestCase(14)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(18)]
    [TestCase(19)]
    [TestCase(20)]
    [TestCase(21)]
    [TestCase(22)]
    [TestCase(23)]
    public async Task ToDictionaryAsync(int overload)
    {
        var a = (Id: 1, Name: "A");
        var b = (Id: 2, Name: "B");
        var c = (Id: 3, Name: "C");
        var source = Enumerable.Create(a, b, c);

        var result = overload switch
        {
            1 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, ct) => ValueTask.FromResult(x.Id)),
            2 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync(x => x.Id, (x, y) => x == y),
            3 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, ct) => ValueTask.FromResult(x.Id), (x, y) => x == y),
            4 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync(x => x.Id, (x, y) => x == y, x => x.GetHashCode()),
            5 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, ct) => ValueTask.FromResult(x.Id), (x, y) => x == y, x => x.GetHashCode()),
            6 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync(x => x.Id, EqualityComparer<int>.Default),
            7 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, ct) => ValueTask.FromResult(x.Id), EqualityComparer<int>.Default),
            8 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync(x => x.Id, x => x),
            9 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, ct) => ValueTask.FromResult(x.Id), (x, ct) => ValueTask.FromResult(x)),
            10 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync(x => x.Id, x => x, (x, y) => x == y),
            11 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, ct) => ValueTask.FromResult(x.Id), (x, ct) => ValueTask.FromResult(x), (x, y) => x == y),
            12 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync(x => x.Id, x => x, (x, y) => x == y, x => x.GetHashCode()),
            13 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, ct) => ValueTask.FromResult(x.Id), (x, ct) => ValueTask.FromResult(x), (x, y) => x == y, x => x.GetHashCode()),
            14 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync(x => x.Id, x => x, EqualityComparer<int>.Default),
            15 => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, ct) => ValueTask.FromResult(x.Id), (x, ct) => ValueTask.FromResult(x), EqualityComparer<int>.Default),
            16 => await source
                .Select(x => new KeyValuePair<int, (int Id, string Name)>(x.Id, x))
                .ToAsyncEnumerable()
                .ToDictionaryAsync(),
            17 => await source
                .Select(x => new KeyValuePair<int, (int Id, string Name)>(x.Id, x))
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, y) => x == y),
            18 => await source
                .Select(x => new KeyValuePair<int, (int Id, string Name)>(x.Id, x))
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, y) => x == y, x => x.GetHashCode()),
            19 => await source
                .Select(x => new KeyValuePair<int, (int Id, string Name)>(x.Id, x))
                .ToAsyncEnumerable()
                .ToDictionaryAsync(EqualityComparer<int>.Default),
            20 => await source
                .Select(x => (x.Id, x))
                .ToAsyncEnumerable()
                .ToDictionaryAsync(),
            21 => await source
                .Select(x => (x.Id, x))
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, y) => x == y),
            22 => await source
                .Select(x => (x.Id, x))
                .ToAsyncEnumerable()
                .ToDictionaryAsync((x, y) => x == y, x => x.GetHashCode()),
            23 => await source
                .Select(x => (x.Id, x))
                .ToAsyncEnumerable()
                .ToDictionaryAsync(EqualityComparer<int>.Default),
            _ => await source
                .ToAsyncEnumerable()
                .ToDictionaryAsync(x => x.Id)
        };
        result.ShouldBe(new Dictionary<int, (int Id, string Name)>()
        {
            { a.Id, a },
            { b.Id, b },
            { c.Id, c }
        });
    }

    [Test]
    public async Task ToDictionaryAsyncCanceled()
    {
        var source = AsyncEnumerable
            .Create(0)
            .AsAsyncIterator();
        var pairSource = AsyncEnumerable
            .Create(new KeyValuePair<int, int>(0, 0))
            .AsAsyncIterator();
        var tupleSource = AsyncEnumerable
            .Create((0, 0))
            .AsAsyncIterator();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, cancellationToken: cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), cancellationToken: cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, (y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, cancellationToken: cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, ct) => ValueTask.FromResult(y), cancellationToken: cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, ct) => ValueTask.FromResult(y), (y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, (y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, ct) => ValueTask.FromResult(y), (y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync(y => y, y => y, EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await source
            .Awaiting(x => x.ToDictionaryAsync((y, ct) => ValueTask.FromResult(y), (y, ct) => ValueTask.FromResult(y), EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(cancellationToken: cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await pairSource
            .Awaiting(x => x.ToDictionaryAsync(EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(cancellationToken: cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync((y, z) => y == z, y => y.GetHashCode(), cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await tupleSource
            .Awaiting(x => x.ToDictionaryAsync(EqualityComparer<int>.Default, cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
