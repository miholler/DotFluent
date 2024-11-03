using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotFluent.Linq;

[TestFixture]
public sealed class AsyncEnumerableCreateTest
{
    #region Methods

    [Test]
    [TestCase(null, new string[0])]
    [TestCase(new string[0], new string[0])]
    [TestCase(new[] { "A", null, "B" }, new[] { "A", null, "B" })]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A", "B", "C" })]
    public async Task Create(string[] source, IEnumerable<string> expectedResult)
    {
        var result = await AsyncSequence
            .Create(source)
            .ToArrayAsync();

        result.ShouldBe(expectedResult);
    }

    #endregion
}
