using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks.Linq
{
    [TestFixture]
    public sealed class SelectManyTest
    {
        #region Methods

        [Test]
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
                .Awaiting(x => x.SelectMany(y => Task.FromResult(++y), resultSelector))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task SelectMany()
        {
            var result = await Task.FromResult(1).SelectMany(x => Task.FromResult(++x));

            result.ShouldBe(2);
        }

        [Test]
        public async Task SelectManyWithResultSelector()
        {
            var result = await Task.FromResult(1).SelectMany(x => Task.FromResult(++x), (x, y) => x + y);

            result.ShouldBe(3);
        }

        #endregion
    }
}
