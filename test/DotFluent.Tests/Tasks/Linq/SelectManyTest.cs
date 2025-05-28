using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks.Linq;

[TestFixture]
public sealed class TaskSelectManyTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<int> source = null;

        await source
            .Awaiting(x => x.SelectMany(Task.FromResult))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SelectMany(Task.FromResult, (y, z) => y + z))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectorNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<int, Task<int>> selector = null;

        await source
            .Awaiting(x => x.SelectMany(selector))
            .ShouldThrowAsync<ArgumentNullException>();
        await source
            .Awaiting(x => x.SelectMany(selector, (y, z) => y + z))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ResultSelectorNullThrowsException()
    {
        var source = Task.FromResult(0);
        Func<int, int, int> resultSelector = null;

        await source
            .Awaiting(x => x.SelectMany(Task.FromResult, resultSelector))
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SelectMany()
    {
        var result = await Task
            .FromResult(1)
            .SelectMany(Task.FromResult);

        result.ShouldBe(1);
    }

    [Test]
    public async Task SelectManyWithResultSelector()
    {
        var task = from x in Task.FromResult(1)
                   from y in Task.FromResult(x)
                   select x + y;

        (await task).ShouldBe(2);
    }

    #endregion
}
