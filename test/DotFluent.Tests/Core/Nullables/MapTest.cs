using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class NullableMapTest
{
    [Test]
    public void MapperNullThrowsException()
    {
        var source = new int?();
        Func<int, int> mapper = null;

        source
            .Invoking(x => x.Map(mapper))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, null)]
    [TestCase(1, 2)]
    public void Map(int? source, int? expectedResult)
        => source
            .Map(x => ++x)
            .ShouldBe(expectedResult);
}
