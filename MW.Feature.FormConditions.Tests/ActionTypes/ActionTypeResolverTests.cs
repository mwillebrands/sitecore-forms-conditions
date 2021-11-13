using MW.Feature.FormConditions.ActionTypes;
using MW.Feature.FormConditions.MatchTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.ActionTypes
{
    [TestClass]
    public class ActionTypeResolverTests
    {
        private ActionTypeResolver _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new ActionTypeResolver();
        }

        [TestMethod]
        public void ResolveShouldReturnDisable()
        {
            Assert.AreEqual(ActionType.Disable, _service.Resolve(Constants.Items.ActionType.Disable));
        }

        [TestMethod]
        public void ResolveShouldReturnEnable()
        {
            Assert.AreEqual(ActionType.Enable, _service.Resolve(Constants.Items.ActionType.Enable));
        }

        [TestMethod]
        public void ResolveShouldReturnGoToPage()
        {
            Assert.AreEqual(ActionType.GoToPage, _service.Resolve(Constants.Items.ActionType.GoToPage));
        }

        [TestMethod]
        public void ResolveShouldReturnHide()
        {
            Assert.AreEqual(ActionType.Hide, _service.Resolve(Constants.Items.ActionType.Hide));
        }

        [TestMethod]
        public void ResolveShouldReturnShow()
        {
            Assert.AreEqual(ActionType.Show, _service.Resolve(Constants.Items.ActionType.Show));
        }
    }
}
