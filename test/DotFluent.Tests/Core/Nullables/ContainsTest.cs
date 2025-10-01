using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class NullableContainsTest
{
    [Test]
    [TestCase(null, 1, false)]
    [TestCase(1, 2, false)]
    [TestCase(1, 1, true)]
    public void Contains(int? source, int value, bool expectedResult)
        => source
            .Contains(value)
            .ShouldBe(expectedResult);
}
