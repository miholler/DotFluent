using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class IndexOfTest
    {
        #region Methods

        [Test]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.IndexOf(0));
            Assert.Throws<ArgumentNullException>(() => source.IndexOf(0, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => source.IndexOf(0, EqualityComparer<int>.Default));
        }

        [Test]
        public void ComparerFunctionNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, int, bool> comparer = null;

            Assert.Throws<ArgumentNullException>(() => source.IndexOf(0, comparer));
        }

        [Test]
        [TestCase(new int[0], 0, -1)]
        [TestCase(new[] { 1, 2, 3 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 1)]
        public void IndexOf(IEnumerable<int> source, int value, int expectedResult)
            => Assert.AreEqual(source.IndexOf(value), expectedResult);

        [Test]
        [TestCase(new int[0], 0, -1)]
        [TestCase(new[] { 1, 2, 3 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 1)]
        public void IndexOfWithComparerFunction(IEnumerable<int> source, int value, int expectedResult)
            => Assert.AreEqual(source.IndexOf(value, (x, y) => x == y), expectedResult);

        [Test]
        [TestCase(new int[0], 0, -1)]
        [TestCase(new[] { 1, 2, 3 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 1)]
        public void IndexOfWithComparer(IEnumerable<int> source, int value, int expectedResult)
            => Assert.AreEqual(source.IndexOf(value, EqualityComparer<int>.Default), expectedResult);

        [Test]
        [TestCase(new int[0], 0, -1)]
        [TestCase(new[] { 1, 2, 3 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 1)]
        public void IndexOfWithNullComparer(IEnumerable<int> source, int value, int expectedResult)
            => Assert.AreEqual(source.IndexOf(value, default(IEqualityComparer<int>)), expectedResult);

        #endregion
    }
}
