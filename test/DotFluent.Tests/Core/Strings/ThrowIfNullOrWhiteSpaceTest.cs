using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringThrowIfNullOrWhiteSpaceTest
{
    [Test]
    public void StringNullOrWhiteSpaceThrowsException()
    {
        string source = null;
        Action action = () => source.ThrowIfNullOrWhiteSpace();

        action.ShouldThrow<ArgumentNullException>()
              .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(source)));

        source = string.Empty;
        action.ShouldThrow<ArgumentException>()
              .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(source)));

        source = "   ";
        action.ShouldThrow<ArgumentException>()
              .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(source)));
    }

    [Test]
    public void StringNotNullNorWhiteSpaceReturnsString()
    {
        var source = "ABC";

        source
            .ThrowIfNullOrWhiteSpace()
            .ShouldBe(source);
    }
}
