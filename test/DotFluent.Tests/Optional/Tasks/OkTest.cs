using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ResultOkTest
{
    #region Methods

    [Test]
    public async Task Ok()
    {
        var result = await ResultTask.Ok(1);

        result.ShouldBe(Result<int>.Ok(1));
    }

    #endregion
}
