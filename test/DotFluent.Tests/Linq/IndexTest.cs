using NUnit.Framework;
using Shouldly;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableIndexTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Index())
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase((object)new string[0])]
    [TestCase((object)new[] { "A", "C", "B" })]
    public void Index(IEnumerable<string> source)
        => source
            .Index()
            .ShouldBe(source
            .Select((x, i) => (i, x)));
}
