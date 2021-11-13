using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class IsGreaterThanOrEqualToOperatorTests
    {
        private IsGreaterThanOrEqualToOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new IsGreaterThanOrEqualToOperator();
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleGreaterThanInt()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 2 }, 1));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleEqualToInt()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 2 }, 2));
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
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidEqualInt()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1, 2, 3 }, 3));
        }


        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllLesserThanAndNotEqualInt()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1, 2, 3 }, 4));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleEqualToDouble()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 2.1D }, 2.1D));
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
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidEqualDouble()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1.1D, 2.1D, 3.1D }, 3.1D));
        }


        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllLesserThanAndNotEqualDouble()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1.1D, 2.1D, 3.1D }, 4.1D));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleEqualToDecimal()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 2.1M }, 2.1M));
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
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidEqualDecimal()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1.1M, 2.1M, 3.1M }, 3.1M));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllLesserThanAndNotEqualDecimal()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { 1.1M, 2.1M, 3.1M }, 4.1M));
        }

    }
}
