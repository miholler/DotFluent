using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace DotFluent.Internal
{
    [TestFixture]
    public sealed class GenericEqualityComparerTest
    {
        #region Methods

        [Test]
        public void ComparerNullThrowsException()
        {
            Func<int, int, bool> comparer = null;

            comparer.Invoking(x => GenericEqualityComparer<int>.Create(x)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void HashCodeProviderNullThrowsException()
        {
            Func<int, int> hashCodeProvider = null;

            hashCodeProvider.Invoking(x => GenericEqualityComparer<int>.Create((l, r) => l == r, x)).ShouldThrow<ArgumentNullException>();
        }

        [Test]
        [TestCase(0, 1, 0, true)]
        [TestCase(0, 1, 1, false)]
        public void EqualsTest(int key, int value, int lookupKey, bool expectedResult)
            => new Dictionary<int, int>(GenericEqualityComparer<int>.Create((x, y) => x == y))
            {
                [key] = value
            }
            .ContainsKey(lookupKey)
            .ShouldBe(expectedResult);

        [Test]
        [TestCase(0, 1, 0, true)]
        [TestCase(0, 1, 1, false)]
        public void GetHashCodeTest(int key, int value, int lookupKey, bool expectedResult)
            => new Dictionary<int, int>(GenericEqualityComparer<int>.Create((x, y) => x == y, x => x.GetHashCode()))
            {
                [key] = value
            }
            .ContainsKey(lookupKey)
            .ShouldBe(expectedResult);

        #endregion
    }
}
