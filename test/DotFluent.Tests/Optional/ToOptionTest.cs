using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OptionToOptionTest
{
    [Test]
    [TestCase(null, new string[0])]
    [TestCase("ABC", new[] { "ABC" })]
    public void ReferenceTypeToOption(string source, IEnumerable<string> expectedResult)
        => source
            .ToOption()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public void ValueTypeToOption(int? source, IEnumerable<int> expectedResult)
        => source
            .ToOption()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    public void ResultToOption(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => source
                    .Match(Result.Ok<int, int>, () => Result.Error<int, int>(0))
                    .ToOption(),
            _ => source
                    .Match(Result.Ok, () => Result.Error<int>(new()))
                    .ToOption()
        };
        result.ShouldBe(expectedResult);
    }
}
