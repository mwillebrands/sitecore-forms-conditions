using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class StartsWithOperatorTests
    {
        private StartsWithOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new StartsWithOperator();
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleValidStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first" }, "fir"));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleInvalidStringMatch()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first" }, "test"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneValidStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first", "second", "nomatch"}, "sec"));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingAllValidStringMatch()
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
