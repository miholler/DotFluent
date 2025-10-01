using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionNoneTest
{
    [Test]
    public async Task None()
    {
        var result = await OptionTask.None<int>();

        result.ShouldBe(Option<int>.None);
    }
}
