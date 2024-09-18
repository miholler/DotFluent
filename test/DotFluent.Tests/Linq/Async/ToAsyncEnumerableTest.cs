using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class ToAsyncEnumerableTest
{
    #region Methods

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
        var source = new[] { 1, 2, 3 };
        var result = source.ToAsyncEnumerable();

        await using var enumerator = result.GetAsyncEnumerator();
        foreach (var item in source)
        {
            var hasNext = await enumerator.MoveNextAsync();
            hasNext.ShouldBeTrue();
            enumerator.Current.ShouldBe(item);
        }
    }

    #endregion
}
