using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableEmptyTest
{
    [Test]
    public async Task Empty()
    {
        var result = await AsyncEnumerable
            .Empty<int>()
            .ToArrayAsync();

        result.ShouldBeEmpty();
    }
}
