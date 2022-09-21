using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace DotFluent.Optional
{
    [TestFixture]
    public sealed class FlattenTest
    {
        #region Methods

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(1, new[] { 1 })]
        public void Flatten(int? source, IEnumerable<int> expectedResult)
            => Option.Some(source.ToOption())
                .Flatten()
                .ShouldBe(expectedResult);

        #endregion
    }
}
