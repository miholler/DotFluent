using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class OptionNoneTest
{
    [Test]
    public void None()
        => Option
            .None<int>()
            .ShouldBe(Option<int>.None);
}
