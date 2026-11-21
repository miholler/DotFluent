using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableCreateTest
{
    [Test]
    [TestCase(null, new string[0])]
    [TestCase(new string[0], new string[0])]
    [TestCase(new[] { "A", null, "B" }, new[] { "A", null, "B" })]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A", "B", "C" })]
    public void Create(IEnumerable<string> source, IEnumerable<string> expectedResult)
        => Enumerable
            .Create(source)
            .ShouldBe(expectedResult);
}
