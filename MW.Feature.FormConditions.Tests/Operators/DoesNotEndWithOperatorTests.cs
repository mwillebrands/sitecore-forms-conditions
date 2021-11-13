using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class DoesNotEndWithOperatorTests
    {
        private DoesNotEndWithOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new DoesNotEndWithOperator();
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleValidStringMatch()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first" }, "irst"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleInvalidStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first" }, "test"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first", "second", "nomatch"}, "ond"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingAllValidStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first", "second", "nomatch" }, "test"));
        }

        [TestMethod]
        public void IsMatchShouldCompareCaseInsensitive()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "A" }, "a"));
        }
    }
}
