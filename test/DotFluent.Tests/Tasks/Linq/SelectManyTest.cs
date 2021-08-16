using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks.Linq
{
    [TestClass]
    public sealed class SelectManyTest
    {
        #region Methods

        [TestMethod]
        public async Task SourceNullThrowsException()
        {
            Task<int> source = null;

            await source
                .Awaiting(x => x.SelectMany(y => Task.FromResult(++y)))
                .ShouldThrowAsync<ArgumentNullException>();
            await source
                .Awaiting(x => x.SelectMany(y => Task.FromResult(++y), (y, z) => y + z))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
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

        [TestMethod]
        public async Task ResultSelectorNullThrowsException()
        {
            var source = Task.FromResult(0);
            Func<int, int, int> resultSelector = null;

            await source
                .Awaiting(x => x.SelectMany(y => Task.FromResult(++y), resultSelector))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task SelectMany()
        {
            var result = await Task.FromResult(1).SelectMany(x => Task.FromResult(++x));

            result.ShouldBe(2);
        }

        [TestMethod]
        public async Task SelectManyWithResultSelector()
        {
            var result = await Task.FromResult(1).SelectMany(x => Task.FromResult(++x), (x, y) => x + y);

            result.ShouldBe(3);
        }

        #endregion
    }
}
