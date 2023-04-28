using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class NoneTest
{
    #region Methods

    [Test]
    public async Task None()
    {
        var result = await OptionTask.None<int>();

        result.ShouldBe(Option<int>.None);
    }

    #endregion
}
