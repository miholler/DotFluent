using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class ToOptionAsyncTest
    {
        #region Methods

        [TestMethod]
        [DataRow(null, new object[] { new string[0] })]
        [DataRow("ABC", new object[] { new[] { "ABC" } })]
        public async Task ReferenceTypeToOptionAsync(string source, IEnumerable<string> expectedResult)
        {
            var result = await source.ToOptionAsync();

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(null, new int[0])]
        [DataRow(1, new[] { 1 })]
        public async Task ValueTypeToOptionAsync(int? source, IEnumerable<int> expectedResult)
        {
            var result = await source.ToOptionAsync();

            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public async Task ToOptionAsyncCanceled()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await string.Empty
                .Awaiting(x => x.ToOptionAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
            await new int?()
                .Awaiting(x => x.ToOptionAsync(cts.Token))
                .ShouldThrowAsync<TaskCanceledException>();
        }

        #endregion
    }
}
