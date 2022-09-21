using NUnit.Framework;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class IsNullOrEmptyTest
    {
        #region Methods

        [Test]
        [TestCase(null, true)]
        [TestCase(new int[0], true)]
        [TestCase(new[] { 1 }, false)]
        public void IsNullOrEmpty(IEnumerable<int> source, bool expectedResult)
            => Assert.AreEqual(source.IsNullOrEmpty(), expectedResult);

        #endregion
    }
}
