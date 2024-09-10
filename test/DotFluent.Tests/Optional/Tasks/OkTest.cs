using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ResultOkTest
{
    #region Methods

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public async Task Ok(int overload)
    {
        switch (overload)
        {
            case 1:
                var result2 = await ResultTask.Ok<int, int>(1);
                result2.ShouldBe(Result<int, int>.Ok(1));
                break;
            default:
                var result = await ResultTask.Ok(1);
                result.ShouldBe(Result<int>.Ok(1));
                break;
        }
    }

    #endregion
}
