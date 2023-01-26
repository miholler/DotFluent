using NUnit.Framework;
using Shouldly;
using System;

namespace DotFluent;

[TestFixture]
public sealed class NullableGetValueOrDefaultTest
{
    #region Methods

    [Test]
    public void DefaultFactoryNullThrowsException()
    {
        var source = new int?();
        Func<int> defaultFactory = null;

        source
            .Invoking(x => x.GetValueOrDefault(defaultFactory))
            .ShouldThrow<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, -1, -1)]
    [TestCase(1, -1, 1)]
    public void GetValueOrDefault(int? source, int defaultValue, int expectedResult)
        => source
            .GetValueOrDefault(() => defaultValue)
            .ShouldBe(expectedResult);

    #endregion
}
