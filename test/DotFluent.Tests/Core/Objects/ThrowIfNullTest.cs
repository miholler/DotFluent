using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace DotFluent
{
    [TestClass]
    public sealed class ObjectThrowIfNullTest
    {
        #region Methods

        [TestMethod]
        public void ObjectNullThrowsException()
        {
            object obj = null;
            Action action = () => obj.ThrowIfNull();

            action
                .ShouldThrow<ArgumentNullException>()
                .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(obj)));
        }

        [TestMethod]
        public void ObjectNullThrowsFactoryException()
        {
            object obj = null;

            obj.Invoking(x => x.ThrowIfNull(() => new ArgumentNullException(nameof(obj))))
               .ShouldThrow<ArgumentNullException>()
               .ShouldSatisfyAllConditions(x => x.ParamName.ShouldBe(nameof(obj)));
        }

        [TestMethod]
        public void ObjectNotNullReturnsObject()
        {
            var obj = new object();

            obj.ThrowIfNull()
               .ShouldBe(obj);
        }

        [TestMethod]
        public void ObjectNotNullReturnsObjectWithFactory()
        {
            var obj = new object();

            obj.ThrowIfNull(() => new ArgumentNullException(nameof(obj)))
               .ShouldBe(obj);
        }

        #endregion
    }
}
