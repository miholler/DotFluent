using NUnit.Framework;
using Shouldly;
using System.Text;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerablePipeTest
{
    [Test]
    public void SourceNullThrowsException()
    {
        IEnumerable<int> source = null;

        source
            .Invoking(x => x.Pipe(y => y++))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe((y, i) => y += i))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void ActionNullThrowsException()
    {
        var source = Enumerable.Empty<int>();
        Action<int> action = null;
        Action<int, int> indexAction = null;

        source
            .Invoking(x => x.Pipe(action))
            .ShouldThrow<ArgumentNullException>();
        source
            .Invoking(x => x.Pipe(indexAction))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(new string[0], new string[0], 0)]
    [TestCase(new string[0], new string[0], 1)]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A#", "B#", "C#" }, 0)]
    [TestCase(new[] { "A", "B", "C" }, new[] { "A0", "B1", "C2" }, 1)]
    public void Pipe(IEnumerable<string> source, IEnumerable<string> expectedResult, int overload)
    {
        var result = source.Select(x => new StringBuilder(x));
        result = overload switch
        {
            1 => result.Pipe((x, i) => x.Append(i)),
            _ => result.Pipe(x => x.Append('#'))
        };
        result
            .Select(x => x.ToString())
            .ShouldBe(expectedResult);
    }
}
