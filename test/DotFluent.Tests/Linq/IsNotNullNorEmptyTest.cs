using NUnit.Framework;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class IsNotNullNorEmptyTest
    {
        #region Methods

        [Test]
        [TestCase(null, false)]
        [TestCase(new int[0], false)]
        [TestCase(new[] { 1 }, true)]
        public void IsNotNullNorEmpty(IEnumerable<int> source, bool expectedResult)
            => Assert.AreEqual(source.IsNotNullNorEmpty(), expectedResult);

        #endregion
    }
}
