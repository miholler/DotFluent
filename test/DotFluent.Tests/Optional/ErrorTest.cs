using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class ErrorTest
{
    #region Methods

    [Test]
    public void Error()
        => Result
            .Error<int>(new())
            .ShouldBe(Result<int>.Error(new()));

    #endregion
}
