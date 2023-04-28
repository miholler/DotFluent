using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks;

[TestFixture]
public sealed class ToOptionAsyncExtensionsTest
{
    #region Methods

    [Test]
    public async Task SourceNullThrowsException()
    {
        Task<string> nullableTask = null;
        Task<int?> nullableValueTask = null;

        await nullableTask
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
        await nullableValueTask
            .Awaiting(x => x.ToOptionAsync())
            .ShouldThrowAsync<ArgumentNullException>();
    }

    [Test]
    [TestCase(null, new string[0])]
    [TestCase("ABC", new[] { "ABC" })]
    public async Task ReferenceTypeToOptionAsync(string source, IEnumerable<string> expectedResult)
    {
        var result = await Task.FromResult(source)
            .ToOptionAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(null, new int[0])]
    [TestCase(1, new[] { 1 })]
    public async Task ValueTypeToOptionAsync(int? source, IEnumerable<int> expectedResult)
    {
        var result = await Task.FromResult(source)
            .ToOptionAsync();

        result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task ToOptionAsyncCanceled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        await Task.FromResult(string.Empty)
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
        await Task.FromResult(new int?())
            .Awaiting(x => x.ToOptionAsync(cts.Token))
            .ShouldThrowAsync<TaskCanceledException>();
    }

    #endregion
}
