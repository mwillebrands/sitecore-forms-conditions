using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class ContainsOperatorTests
    {
        private ContainsOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new ContainsOperator();
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSinglePartialStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first" }, "irst"));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleInvalidStringMatch()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first" }, "test"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultiplePartialStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first", "second" }, "sec"));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesThatAreInvalid()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first", "second", "nomatch" }, "test"));
        }

        [TestMethod]
        public void IsMatchShouldCompareCaseInsensitive()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "A" }, "a"));
        }
    }
}
