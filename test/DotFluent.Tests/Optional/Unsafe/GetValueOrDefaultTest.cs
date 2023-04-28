using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent.Optional.Unsafe;

[TestFixture]
public sealed class GetValueOrDefaultTest
{
    #region Methods

    [Test]
    public void DefaultFactoryNullThrowsExcption()
    {
        var option = Option.None<int>();
        Func<int> defaultFactory = null;

        option.Invoking(x => x.GetValueOrDefault(defaultFactory)).ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, 0)]
    [TestCase(1, 1)]
    public void GetValueOrDefault(int? source, int expectedResult)
        => source
            .ToOption()
            .GetValueOrDefault()
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(null, 1, 1)]
    [TestCase(1, 2, 1)]
    public void GetValueOrDefaultWithDefaultValue(int? source, int defaultValue, int expectedResult)
        => source
            .ToOption()
            .GetValueOrDefault(defaultValue)
            .ShouldBe(expectedResult);

    [Test]
    [TestCase(null, 1, 1)]
    [TestCase(1, 2, 1)]
    public void GetValueOrDefaultWithDefaultFactory(int? source, int defaultValue, int expectedResult)
        => source
            .ToOption()
            .GetValueOrDefault(() => defaultValue)
            .ShouldBe(expectedResult);

    #endregion
}
