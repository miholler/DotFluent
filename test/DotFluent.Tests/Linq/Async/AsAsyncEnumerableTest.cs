using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableAsAsyncEnumerableTest
{
    #region Methods

    [Test]
    public void AsAsyncEnumerable()
    {
        var source = AsyncSequence.Create(1, 2, 3);
        var result = source.AsAsyncEnumerable();

        result.ShouldBe(source);
    }

    #endregion
}
