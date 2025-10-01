using NUnit.Framework;
using Shouldly;
using System.Collections.Immutable;

namespace DotFluent.Linq;

[TestFixture]
public sealed class EnumerableInsertRangeTest
{
    [Test]
    [TestCase(null, new int[0])]
    [TestCase(new int[0], null)]
    public void FirstOrSecondNullThrowsException(IEnumerable<int> first, IEnumerable<int> second)
        => first
            .Invoking(x => x.InsertRange(0, second))
            .ShouldThrow<ArgumentNullException>();

    [Test]
    [TestCase(new int[0], -1, new int[0])]
    [TestCase(new[] { 1, 2 }, 3, new int[0])]
    public void IndexOutOfRangeThrowsException(IEnumerable<int> first, int index, IEnumerable<int> second)
        => first
            .Invoking(x => x
                .InsertRange(index, second)
                .ToImmutableArray())
            .ShouldThrow<ArgumentOutOfRangeException>();

    [Test]
    [TestCase(new int[0], 0, new int[0], new int[0])]
    [TestCase(new[] { 1, 2, 3 }, 0, new int[0], new[] { 1, 2, 3 })]
    [TestCase(new int[0], 0, new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 4 }, 1, new[] { 2, 3 }, new[] { 1, 2, 3, 4 })]
    public void InsertRange(IEnumerable<int> first, int index, IEnumerable<int> second, IEnumerable<int> expectedResult)
        => first
            .InsertRange(index, second)
            .ShouldBe(expectedResult);
}
