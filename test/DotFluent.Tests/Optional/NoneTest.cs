using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class NoneTest
{
    #region Methods

    [Test]
    public void None()
        => Option.None<int>().ShouldBe(Option<int>.None);

    #endregion
}
