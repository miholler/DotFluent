using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DotFluent.Tests.Enumerable
{
    [TestClass]
    public sealed class CreateTest
    {
        #region Methods

        [TestMethod]
        public void CreateEmpty()
        {
            var source = Sequence.Create<int>();

            Assert.IsTrue(source.IsNotNull() && source.None());
        }

        [TestMethod]
        public void CreateWithArrayNull()
        {
            object[] elements = null;
            var source = Sequence.Create(elements);

            Assert.IsTrue(source.IsNotNull() && source.None());
        }

        [TestMethod]
        public void CreateWithElementNull()
        {
            var source = Sequence.Create(new object(), null, new object()).ToArray();

            Assert.IsTrue(source.IsNotNullOrEmpty() && source.Contains(null));
        }

        [TestMethod]
        public void Create()
        {
            var source = Sequence.Create(1, 2, 3).ToArray();

            Assert.IsTrue(source.IsNotNullOrEmpty() && source.SequenceEqual(new[] { 1, 2, 3 }));
        }

        #endregion
    }
}
