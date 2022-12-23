using NUnit.Framework;
using Shouldly;

namespace DotFluent;

[TestFixture]
public sealed class NullableIsSomeTest
{
    #region Methods

    [Test]
    [TestCase(null, false)]
    [TestCase(1, true)]
    public void IsSome(int? source, bool expectedResult)
        => source
            .IsSome()
            .ShouldBe(expectedResult);

    #endregion
}
