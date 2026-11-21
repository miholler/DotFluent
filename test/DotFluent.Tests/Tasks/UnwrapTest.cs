using NUnit.Framework;
using Shouldly;

namespace DotFluent.Tasks;

[TestFixture]
public sealed class ValueTaskUnwrapTest
{
    [Test]
    [TestCase(1, 1, 0)]
    [TestCase(1, 1, 1)]
    public async Task Unwrap(int value, int expectedResult, int overload)
    {
        var result = 0;

        switch (overload)
        {
            case 1:
                result = await ValueTask
                    .FromResult(new ValueTask<int>(Task.FromResult(result + value)))
                    .Unwrap();
                break;
            default:
                await ValueTask
                    .FromResult(new ValueTask(Task.Run(() => { result += value; })))
                    .Unwrap();
                break;
        }
        result.ShouldBe(expectedResult);
    }
}
