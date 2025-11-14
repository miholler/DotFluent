using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionSecureAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<int>> optionTask = null;

        await optionTask
            .Awaiting(x => x.SecureAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase("A", new[] { "A" }, 0)]
    [TestCase("A", new[] { "A" }, 1)]
    [TestCase(null, new string[0], 0)]
    [TestCase(null, new string[0], 1)]
    public async Task SecureAsync(string source, IEnumerable<string> expectedResult, int overload)
    {
        var result = overload switch
        {
            1 => await OptionTask
                .Some(source)
                .SecureAsync(),
            _ => await Option
                .Some(source)
                .SecureAsync()
        };
        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task SecureAsyncCanceled()
    {
        var option = Option.None<int>();
        var optionTask = OptionTask.None<int>();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await option
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await optionTask
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
