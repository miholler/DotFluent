using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class ResultErrorTest
{
    #region Methods

    [Test]
    public void Error()
        => Result
            .Error<int>(new())
            .ShouldBe(Result<int>.Error(new()));

    #endregion
}
