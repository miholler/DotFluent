using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsAsyncEnumerableTest
{
    #region Methods

    [Test]
    public void AsAsyncEnumerable()
    {
        var source = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var result = source.AsAsyncEnumerable();

        result.ShouldBe(source);
    }

    #endregion
}
