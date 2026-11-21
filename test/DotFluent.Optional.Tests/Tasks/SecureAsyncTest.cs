using NUnit.Framework;
using Shouldly;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class OptionSecureAsyncTest
{
    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<Option<string>> optionTask = null;
        Task<Option<int?>> optionValueTask = null;

        await optionTask
            .Awaiting(x => x.SecureAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await optionValueTask
            .Awaiting(x => x.SecureAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase("A", new[] { "A" }, 0)]
    [TestCase("A", new[] { "A" }, 1)]
    [TestCase(null, new string[0], 0)]
    [TestCase(null, new string[0], 1)]
    public async Task ReferenceTypeSecureAsync(string source, IEnumerable<string> expectedResult, int overload)
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
    [TestCase(1, new[] { 1 }, 0)]
    [TestCase(1, new[] { 1 }, 1)]
    [TestCase(null, new int[0], 0)]
    [TestCase(null, new int[0], 1)]
    public async Task ValueTypeSecureAsync(int? source, IEnumerable<int> expectedResult, int overload)
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
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await Option
            .None<string>()
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Option
            .None<int?>()
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await OptionTask
            .None<string>()
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await OptionTask
            .None<int?>()
            .Awaiting(x => x.SecureAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }
}
