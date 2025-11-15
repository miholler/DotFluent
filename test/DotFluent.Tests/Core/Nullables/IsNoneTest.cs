using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class NullableIsNoneTest
{
    [Test]
    [TestCase(null, true)]
    [TestCase(1, false)]
    public void IsNone(int? source, bool expectedResult)
        => source.IsNone.ShouldBe(expectedResult);
}
