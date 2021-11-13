using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class IsNotEqualToOperatorTests
    {
        private IsNotEqualToOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new IsNotEqualToOperator();
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleNotEqualStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first" }, "irst"));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleEqualStringMatch()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first" }, "first"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesHavingOneEqual()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first", "second" }, "second"));
        }

        [TestMethod]
        public void IsMatchShouldMatchOnMultipleValuesThatAreInvalid()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first", "second", "nomatch" }, "test"));
        }
    }
}
