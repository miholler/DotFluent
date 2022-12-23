using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Optional.Linq
{
    [TestFixture]
    public sealed class SelectTest
    {
        #region Methods

        [Test]
        public void SelectorNullThrowsException()
        {
            var option = Option.None<int>();
            Func<int, int> selector = null;

            option
                .Invoking(x => x.Select(selector))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(1, new[] { 1 })]
        public void Select(int? source, IEnumerable<int> expectedResult)
        {
            var result = from x in source.ToOption()
                         select x;

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
