using System.Collections.Generic;
using MW.Feature.FormConditions.Operators.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class IsEqualToOperatorTests
    {
        private IsEqualToOperator _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new IsEqualToOperator();
        }

        [TestMethod]
        public void IsMatchShouldMatchOnSingleValidStringMatch()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { "first" }, "first"));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnSingleInvalidStringMatch()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first" }, "test"));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesHavingOneValid()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first", "second" }, "second"));
        }

        [TestMethod]
        public void IsMatchShouldNotMatchOnMultipleValuesThatAreInvalid()
        {
            Assert.IsFalse(_service.IsMatch(new List<object>() { "first", "second", "nomatch" }, "test"));
        }

        [TestMethod]
        public void IsMatchShouldHandleIntStringTypeDifference()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { 1 }, "1"));
        }


        [TestMethod]
        public void IsMatchShouldMatchNullWithValueEmptyString()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() { null }, ""));
        }

        [TestMethod]
        public void IsMatchShouldMatchNullWithOperatorEmptyString()
        {
            Assert.IsTrue(_service.IsMatch(new List<object>() {""}, null));
        }
    }
}
