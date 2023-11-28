using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ResultErrorTest
{
    #region Methods

    [Test]
    public async Task Error()
    {
        var result = await ResultTask.Error<int>(new());

        result.ShouldBe(Result<int>.Error(new()));
    }

    #endregion
}
