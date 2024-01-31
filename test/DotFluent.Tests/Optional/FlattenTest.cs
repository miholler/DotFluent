using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OptionFlattenTest
{
    #region Methods

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public void Flatten(int? source, IEnumerable<int> expectedResult)
        => Option
            .Some(source.ToOption())
            .Flatten()
            .ShouldBe(expectedResult);

    #endregion
}

[TestFixture]
public sealed class ResultFlattenTest
{
    #region Methods

    [Test]
    [TestCase(1, new[] { 1 })]
    [TestCase(null, new int[0])]
    public void Flatten(int? source, IEnumerable<int> expectedResult)
        => Result
            .Ok(source.Match(Result<int>.Ok, () => Result<int>.Error(new())))
            .Flatten()
            .ShouldBe(expectedResult);

    #endregion
}
