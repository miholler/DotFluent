using DotFluent.Tasks.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tests.Tasks.Linq
{
    [TestClass]
    public sealed class SelectTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<int> source = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Select(x => x++));
        }

        [TestMethod]
        public async Task SelectorNullThrowsException()
        {
            var source = Task.FromResult(1);
            Func<int, int> selector = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.Select(selector));
        }

        [TestMethod]
        public async Task Select()
        {
            var result = await Task.FromResult(1).Select(x => ++x);

            Assert.AreEqual(result, 2);
        }

        #endregion
    }
}
