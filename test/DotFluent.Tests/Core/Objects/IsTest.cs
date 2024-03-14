using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent;

[TestFixture]
public sealed class ObjectIsTest
{
    #region Methods

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = string.Empty;
        Func<string, bool> predicate = null;

        source
            .Invoking(x => x.Is(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, false)]
    [TestCase("", false)]
    [TestCase("ABC", true)]
    public void Is(string source, bool expectedResult)
        => source
            .Is(x => x.Length > 0)
            .ShouldBe(expectedResult);

    #endregion
}
