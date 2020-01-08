using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tests.Tasks
{
    [TestClass]
    public sealed class SelectManyTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<int> source = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.SelectMany(x => Task.FromResult(++x)));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.SelectMany(x => Task.FromResult(++x), (x, y) => x + y));
        }

        [TestMethod]
        public async Task SelectorNullThrowsException()
        {
            var source = Task.FromResult(1);
            Func<int, Task<int>> selector = null; 

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.SelectMany(selector));
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.SelectMany(selector, (x, y) => x + y));
        }

        [TestMethod]
        public async Task ResultSelectorNullThrowsException()
        {
            var source = Task.FromResult(1);
            Func<int, int, int> resultSelector = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => source.SelectMany(x => Task.FromResult(++x), resultSelector));
        }

        [TestMethod]
        public async Task SelectMany()
        {
            var result = await Task.FromResult(1).SelectMany(x => Task.FromResult(++x));

            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public async Task SelectManyWithResultSelector()
        {
            var result = await Task.FromResult(1).SelectMany(x => Task.FromResult(++x), (x, y) => x + y);

            Assert.AreEqual(result, 3);
        }

        #endregion
    }
}
