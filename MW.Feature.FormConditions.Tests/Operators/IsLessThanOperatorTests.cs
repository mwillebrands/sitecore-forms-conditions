using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class IsLessThanOperatorTests
    {
        private IsLessThanOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new IsLessThanOperator();
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleLesserThanInt()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1 }, 2));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleGreaterThanInt()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 2 }, 1));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidLesserThanInt()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1, 2, 3 }, 2));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllGreaterThanInt()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1, 2, 3 }, 0));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleLesserThanDouble()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1.1D }, 2.1D));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleGreaterThanDouble()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 2.1D }, 1.1D));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidLesserThanDouble()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1.1D, 2.1D, 3.1D }, 2.1D));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllGreaterThanDouble()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1.1D, 2.1D, 3.1D }, 0D));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleLesserThanDecimal()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1.1M }, 2.1M));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleGreaterThanDecimal()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 2.1M }, 1.1M));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidLesserThanDecimal()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1.1M, 2.1M, 3.1M }, 2.1M));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllLesserThanDecimal()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1.1M, 2.1M, 3.1M }, 0M));
        }
    }
}
