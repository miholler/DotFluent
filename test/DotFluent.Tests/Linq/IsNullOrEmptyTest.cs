using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableIsNullOrEmptyTest
{
    #region Methods

    [Test]
    [TestCase(null, true)]
    [TestCase(new int[0], true)]
    [TestCase(new[] { 1 }, false)]
    public void IsNullOrEmpty(IEnumerable<int> source, bool expectedResult)
        => source
            .IsNullOrEmpty()
            .ShouldBe(expectedResult);

    #endregion
}
