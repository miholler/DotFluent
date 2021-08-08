using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Threading.Tasks;

namespace DotFluent.Optional.Tasks
{
    [TestClass]
    public sealed class NoneTest
    {
        #region Methods

        [TestMethod]
        public async Task None()
        {
            var result = await OptionTask.None<int>();

            result.ShouldBe(Option<int>.None);
        }

        #endregion
    }
}
