using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OkTest
{
    #region Methods

    [Test]
    public void Ok()
        => Result
            .Ok(1)
            .ShouldBe(Result<int>.Ok(1));

    #endregion
}
