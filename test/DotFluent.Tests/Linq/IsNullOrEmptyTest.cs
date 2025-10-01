using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableIsNullOrEmptyTest
{
    [Test]
    [TestCase(null, true)]
    [TestCase(new int[0], true)]
    [TestCase(new[] { 1 }, false)]
    public void IsNullOrEmpty(IEnumerable<int> source, bool expectedResult)
        => source
            .IsNullOrEmpty()
            .ShouldBe(expectedResult);
}
