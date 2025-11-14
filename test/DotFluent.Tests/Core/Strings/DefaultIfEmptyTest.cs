using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringDefaultIfEmptyTest
{
    [Test]
    public void DefaultFactoryNullThrowsException()
    {
        var source = string.Empty;
        Func<string> defaultFactory = null;

        source
            .Invoking(x => x.DefaultIfEmpty(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, "DEF", "DEF", 0)]
    [TestCase(null, "DEF", "DEF", 1)]
    [TestCase("", "DEF", "DEF", 0)]
    [TestCase("", "DEF", "DEF", 1)]
    [TestCase("   ", "DEF", "DEF", 0)]
    [TestCase("   ", "DEF", "DEF", 1)]
    [TestCase("ABC", "DEF", "ABC", 0)]
    [TestCase("ABC", "DEF", "ABC", 1)]
    public void DefaultIfEmpty(string source, string defaultValue, string expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source.DefaultIfEmpty(() => defaultValue),
            _ => source.DefaultIfEmpty(defaultValue)
        };
        result.ShouldBe(expectedResult);
    }
}
