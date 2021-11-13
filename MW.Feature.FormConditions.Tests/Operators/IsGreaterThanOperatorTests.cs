using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class IsGreaterThanOperatorTests
    {
        private IsGreaterThanOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new IsGreaterThanOperator();
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleGreaterThanInt()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 2 }, 1));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleLesserThanInt()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1 }, 2));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidGreaterThanInt()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1, 2, 3 }, 1));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllLesserThanInt()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1, 2, 3 }, 3));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleGreaterThanDouble()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 2.1D }, 1.1D));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleLesserThanDouble()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1.1D }, 2.1D));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidGreaterThanDouble()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1.1D, 2.1D, 3.1D }, 1.1D));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllLesserThanDouble()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1.1D, 2.1D, 3.1D }, 3.1D));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleLesserThanDecimal()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 2.1M }, 1.1M));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleLesserThanDecimal()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1.1M }, 2.1M));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidGreaterThanDecimal()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1.1M, 2.1M, 3.1M }, 1.1M));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllLesserThanDecimal()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1.1M, 2.1M, 3.1M }, 3.1M));
        }
    }
}
