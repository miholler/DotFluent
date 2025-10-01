using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class ResultErrorTest
{
    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public void Error(int overload)
    {
        switch (overload)
        {
            case 1:
                Result
                    .Error<int, int>(0)
                    .ShouldBe(Result<int, int>.Error(0));
                break;
            default:
                Result
                    .Error<int>(new())
                    .ShouldBe(Result<int>.Error(new()));
                break;
        }
    }
}
