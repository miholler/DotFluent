using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OptionSecureTest
{
    [Test]
    [TestCase("ABC", new[] { "ABC" })]
    [TestCase(null, new string[0])]
    public void ReferenceTypeSecure(string source, IEnumerable<string> expectedResult)
        => Option
            .Some(source)
            .Secure()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(1, new[] { 1 })]
    [TestCase(null, new int[0])]
    public void ValueTypeSecure(int? source, IEnumerable<int> expectedResult)
        => Option
            .Some(source)
            .Secure()
            .ShouldBe(expectedResult);
}
