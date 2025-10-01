using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class StringThrowIfNullOrEmptyTest
{
    [Test]
    public void StringNullOrEmptyThrowsException()
    {
        string source = null;
        Action action = () => source.ThrowIfNullOrEmpty();

        action.ShouldThrow<ArgumentNullException>()
              .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(source)));

        source = string.Empty;
        action.ShouldThrow<ArgumentException>()
              .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(source)));
    }

    [Test]
    public void StringNotNullNorEmptyReturnsString()
    {
        var source = "ABC";

        source
            .ThrowIfNullOrEmpty()
            .ShouldBe(source);
    }
}
