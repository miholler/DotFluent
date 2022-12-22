using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Optional.Linq
{
    [TestFixture]
    public sealed class WhereTest
    {
        #region Methods

        [Test]
        public void PredicateNullThrowsException()
        {
            var source = Option.None<int>();
            Func<int, bool> predicate = null;

            source
                .Invoking(x => x.Where(predicate))
                .ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(null, new int[0])]
        [TestCase(1, new int[0])]
        [TestCase(2, new[] { 2 })]
        public void Where(int? source, IEnumerable<int> expectedResult)
        {
            var result = from x in source.ToOption()
                         where x % 2 == 0
                         select x;

            result.ShouldBe(expectedResult);
        }

        #endregion
    }
}
