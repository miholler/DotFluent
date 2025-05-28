using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableDefaultIfEmptyTest
{
    #region Methods

    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.DefaultIfEmpty(() => 0))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void DefaultFactoryNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Func<int> defaultFactory = null;

        source
            .Invoking(x => x.DefaultIfEmpty(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new int[0], new[] { 0 })]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    public void DefaultIfEmpty(IEnumerable<int> source, IEnumerable<int> expectedResult)
        => source
            .DefaultIfEmpty(() => 0)
            .ShouldBe(expectedResult);

    #endregion
}
