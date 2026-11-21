using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableToAsyncEnumerableTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.ToAsyncEnumerable())
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public async Task ToAsyncEnumerable()
    {
        var source = Enumerable.Create(1, 2, 3);
        var result = await source
            .ToAsyncEnumerable()
            .ToArrayAsync();

        result.ShouldBe(source);
    }
}
