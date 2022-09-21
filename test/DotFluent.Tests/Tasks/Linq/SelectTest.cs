using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace DotFluent.Tasks.Linq
{
    [TestFixture]
    public sealed class SelectTest
    {
        #region Methods

        [Test]
        public async Task SourceNullThrowsException()
        {
            Task<int> source = null;

            await source
                .Awaiting(x => x.Select(y => y++))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task SelectorNullThrowsException()
        {
            var source = Task.FromResult(1);
            Func<int, int> selector = null;

            await source
                .Awaiting(x => x.Select(selector))
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task Select()
        {
            var result = await Task.FromResult(1).Select(x => ++x);

            result.ShouldBe(2);
        }

        #endregion
    }
}
