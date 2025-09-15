using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class ObjectIsNotTest
{
    #region Methods

    [Test]
    public void PredicateNullThrowsException()
    {
        var source = string.Empty;
        Func<string, bool> predicate = null;

        source
            .Invoking(x => x.IsNot(predicate))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, true)]
    [TestCase("", true)]
    [TestCase("ABC", false)]
    public void IsNot(string source, bool expectedResult)
        => source
            .IsNot(x => x.Length > 0)
            .ShouldBe(expectedResult);

    #endregion
}
