using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OptionToOptionTest
{
    #region Methods

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
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public void ResultToOption(int? source, IEnumerable<int> expectedResult)
        => source
            .Match(Result.Ok, () => Result.Error<int>(new()))
            .ToOption()
            .ShouldBe(expectedResult);

    #endregion
}
