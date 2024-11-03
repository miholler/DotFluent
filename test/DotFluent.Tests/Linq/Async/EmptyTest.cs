using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableEmptyTest
{
    #region Methods

    [Test]
    public async Task Empty()
    {
        await using var enumerator = AsyncSequence
            .Empty<int>()
            .GetAsyncEnumerator();

        var hasNext = await enumerator.MoveNextAsync();
        hasNext.ShouldBeFalse();
    }

    #endregion
}
