using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ResultErrorTest
{
    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public async Task Error(int overload)
    {
        switch (overload)
        {
            case 1:
                var result2 = await ResultTask.Error<int, int>(0);
                result2.ShouldBe(Result<int, int>.Error(0));
                break;
            default:
                var result = await ResultTask.Error<int>(new());
                result.ShouldBe(Result<int>.Error(new()));
                break;
        }
    }
}
