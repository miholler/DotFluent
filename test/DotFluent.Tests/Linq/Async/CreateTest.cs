using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableCreateTest
{
    [Test]
    [TestCase(null, new string[0])]
    [TestCase(new string[0], new string[0])]
    [TestCase(new[] { "A", null, "B" }, new[] { "A", null, "B" })]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A", "B", "C" })]
    public async Task Create(IEnumerable<string> source, IEnumerable<string> expectedResult)
    {
        var result = await AsyncEnumerable
            .Create(source)
            .ToArrayAsync();

        result.ShouldBe(expectedResult);
    }
}
