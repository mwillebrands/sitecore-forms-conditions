using System;
using System.Collections.Generic;
using MW.Feature.FormConditions.Operators;
using MW.Feature.FormConditions.Operators.Implementations;
using MW.Feature.FormConditions.Operators.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MW.Feature.FormConditions.Tests.Operators
{
    [TestClass]
    public class OperatorFactoryTests
    {
        private OperatorFactory _service;

        [TestInitialize]
        public void Initialize()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(x => x.GetService(typeof(IEnumerable<IOperator>))).Returns(
                new List<IOperator>()
                {
                    new ContainsOperator(),
                    new DoesNotContainOperator(),
                    new DoesNotEndWithOperator(),
                    new DoesNotStartWithOperator(),
                    new EndsWithOperator(),
                    new IsEqualToOperator(),
                    new IsGreaterThanOperator(),
                    new IsGreaterThanOrEqualToOperator(),
                    new IsLessThanOperator(),
                    new IsLessThanOrEqualToOperator(),
                    new IsNotEqualToOperator(),
                    new StartsWithOperator()
                });
            _service = new OperatorFactory(serviceProviderMock.Object);
        }

        [TestMethod]
        public void GetOperatorShouldReturnContains()
        {
            Assert.AreEqual(typeof(ContainsOperator), _service.GetOperator(Constants.Items.Operator.Contains).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnDoesNotContain()
        {
            Assert.AreEqual(typeof(DoesNotContainOperator), _service.GetOperator(Constants.Items.Operator.DoesNotContain).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnDoesNotEndWith()
        {
            Assert.AreEqual(typeof(DoesNotEndWithOperator), _service.GetOperator(Constants.Items.Operator.DoesNotEndWith).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnDoesNotStartWith()
        {
            Assert.AreEqual(typeof(DoesNotStartWithOperator), _service.GetOperator(Constants.Items.Operator.DoesNotStartWith).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnEndsWith()
        {
            Assert.AreEqual(typeof(EndsWithOperator), _service.GetOperator(Constants.Items.Operator.EndsWith).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnIsEqualTo()
        {
            Assert.AreEqual(typeof(IsEqualToOperator), _service.GetOperator(Constants.Items.Operator.IsEqualTo).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnIsGreaterThan()
        {
            Assert.AreEqual(typeof(IsGreaterThanOperator), _service.GetOperator(Constants.Items.Operator.IsGreaterThan).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnIsGreaterThanOrEqualTo()
        {
            Assert.AreEqual(typeof(IsGreaterThanOrEqualToOperator), _service.GetOperator(Constants.Items.Operator.IsGreaterThanOrEqualTo).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnIsLessThan()
        {
            Assert.AreEqual(typeof(IsLessThanOperator), _service.GetOperator(Constants.Items.Operator.IsLessThanOperator).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnIsLessThanOrEqualTo()
        {
            Assert.AreEqual(typeof(IsLessThanOrEqualToOperator), _service.GetOperator(Constants.Items.Operator.IsLessThanOrEqualTo).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnIsNotEqualTo()
        {
            Assert.AreEqual(typeof(IsNotEqualToOperator), _service.GetOperator(Constants.Items.Operator.IsNotEqualTo).GetType());
        }

        [TestMethod]
        public void GetOperatorShouldReturnStartsWith()
        {
            Assert.AreEqual(typeof(StartsWithOperator), _service.GetOperator(Constants.Items.Operator.StartsWith).GetType());
        }
    }
}
