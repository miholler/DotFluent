using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class ToOptionAsyncExtensionsTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<int?> nullableTask = null;

            await nullableTask
                .Awaiting(x => x.ToOptionAsync())
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public async Task ToOptionAsync(int? source, IEnumerable<int> expectedResult)
        {
            var result = await Task.FromResult(source)
                .ToOptionAsync();

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task ToOptionAsyncCanceled()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await Task.FromResult(new int?())
                .Awaiting(x => x.ToOptionAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
