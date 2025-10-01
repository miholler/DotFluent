using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional;

[TestFixture]
public sealed class ResultOkTest
{
    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public void Ok(int overload)
    {
        switch(overload)
        {
            case 1:
                Result
                    .Ok<int, int>(1)
                    .ShouldBe(Result<int, int>.Ok(1));
                break;
            default:
                Result
                    .Ok(1)
                    .ShouldBe(Result<int>.Ok(1));
                break;
        }
    }
}
