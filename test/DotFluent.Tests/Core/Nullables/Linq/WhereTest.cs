using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent.Linq;

[TestFixture]
public sealed class NullableWhereTest
{
    #region Methods

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = new int?();
        Func<int, bool> predicate = null;

        source
            .Invoking(x => x.Where(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, null)]
    [TestCase(1, null)]
    [TestCase(2, 2)]
    public void Where(int? source, int? expectedResult)
    {
        var result = from x in source
                     where x % 2 == 0
                     select x;

        result.ShouldBe(expectedResult);
    }

    #endregion
}
