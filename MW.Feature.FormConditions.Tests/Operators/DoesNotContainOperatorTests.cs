using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class DoesNotContainOperatorTests
    {
        private DoesNotContainOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new DoesNotContainOperator();
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSinglePartialStringMatch()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first" }, "irst"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleInvalidStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first" }, "test"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultiplePartialStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first", "second", "nomatch"}, "sec"));
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
