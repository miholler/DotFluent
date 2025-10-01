using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionSomeTest
{
    [Test]
    public async Task Some()
    {
        var result = await OptionTask.Some(1);

        result.ShouldBe(Option<int>.Some(1));
    }
}
