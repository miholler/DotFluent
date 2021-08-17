using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks.Linq
{
    [TestClass]
    public sealed class SelectTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<int> source = null;

            await source
                .Awaiting(x => x.Select(y => y++))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task SelectorNullThrowsException()
        {
            var source = Task.FromResult(1);
            Func<int, int> selector = null;

            await source
                .Awaiting(x => x.Select(selector))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task Select()
        {
            var result = await Task.FromResult(1).Select(x => ++x);

            result.ShouldBe(2);
        }

        #endregion
    }
}
