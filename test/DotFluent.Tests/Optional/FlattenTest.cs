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
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    public void Flatten(int? source, IEnumerable<int> expectedResult, int overload)
    {
        var currentResult = overload switch
        {
            1 => Result
                    .Ok<Result<int, int>, int>(source.Match(Result.Ok<int, int>, () => Result.Error<int, int>(0)))
                    .Flatten()
                    .AsEnumerable(),
            _ => Result
                    .Ok(source.Match(Result.Ok, () => Result.Error<int>(new())))
                    .Flatten()
                    .AsEnumerable()
        };

        currentResult.ShouldBe(expectedResult);
    }

    #endregion
}
