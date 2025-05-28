using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableIsNotNullNorEmptyTest
{
    #region Methods

    [Test]
    [TestCase(null, false)]
    [TestCase(new int[0], false)]
    [TestCase(new[] { 1 }, true)]
    public void IsNotNullNorEmpty(IEnumerable<int> source, bool expectedResult)
        => source
            .IsNotNullNorEmpty()
            .ShouldBe(expectedResult);

    #endregion
}
