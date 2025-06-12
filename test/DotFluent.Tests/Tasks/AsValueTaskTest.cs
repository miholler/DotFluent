using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks;

public sealed class TaskAsValueTaskTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task source = null;
        Task<int> genericSource = null;

        await source
            .Awaiting(x => x.AsValueTask())
            .ShouldThrowAsync<ArgumentNullException>();
        await genericSource
            .Awaiting(x => x.AsValueTask())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(1, 1, 0)]
    [TestCase(1, 1, 1)]
    public async Task AsValueTask(int value, int expectedResult, int overload)
    {
        var result = 0;
        switch (overload)
        {
            case 1:
                result = await Task
                    .Run(() => result + value)
                    .AsValueTask();
                break;
            default:
                await Task
                    .Run(() => { result += value; })
                    .AsValueTask();
                break;
        }
        result.ShouldBe(expectedResult);
    }

    #endregion
}
