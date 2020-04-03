using DotFluent.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DotFluent.Tests.Linq
{
    [TestClass]
    public sealed class IndexOfTest
    {
        #region Methods

        [TestMethod]
        public void SourceNullThrowsException()
        {
            IEnumerable<int> source = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.IndexOf(0));
            Assert.ThrowsException<ArgumentNullException>(() => source.IndexOf(0, (x, y) => x == y));
            Assert.ThrowsException<ArgumentNullException>(() => source.IndexOf(0, EqualityComparer<int>.Default));
        }

        [TestMethod]
        public void ComparerFunctionNullThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            Func<int, int, bool> comparer = null;

            Assert.ThrowsException<ArgumentNullException>(() => source.IndexOf(0, comparer));
        }

        [TestMethod]
        [DataRow(new int[0], 0, -1)]
        [DataRow(new[] { 1, 2, 3 }, 2, 1)]
        [DataRow(new[] { 1, 2, 3, 2 }, 2, 1)]
        public void IndexOf(IEnumerable<int> source, int value, int expectedResult)
            => Assert.AreEqual(source.IndexOf(value), expectedResult);

        [TestMethod]
        [DataRow(new int[0], 0, -1)]
        [DataRow(new[] { 1, 2, 3 }, 2, 1)]
        [DataRow(new[] { 1, 2, 3, 2 }, 2, 1)]
        public void IndexOfWithComparerFunction(IEnumerable<int> source, int value, int expectedResult)
            => Assert.AreEqual(source.IndexOf(value, (x, y) => x == y), expectedResult);

        [TestMethod]
        [DataRow(new int[0], 0, -1)]
        [DataRow(new[] { 1, 2, 3 }, 2, 1)]
        [DataRow(new[] { 1, 2, 3, 2 }, 2, 1)]
        public void IndexOfWithComparer(IEnumerable<int> source, int value, int expectedResult)
            => Assert.AreEqual(source.IndexOf(value, EqualityComparer<int>.Default), expectedResult);

        [TestMethod]
        [DataRow(new int[0], 0, -1)]
        [DataRow(new[] { 1, 2, 3 }, 2, 1)]
        [DataRow(new[] { 1, 2, 3, 2 }, 2, 1)]
        public void IndexOfWithNullComparer(IEnumerable<int> source, int value, int expectedResult)
            => Assert.AreEqual(source.IndexOf(value, default(IEqualityComparer<int>)), expectedResult);

        #endregion
    }
}
