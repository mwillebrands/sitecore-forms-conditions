using MW.Feature.FormConditions.MatchTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MW.Feature.FormConditions.Tests.MatchTypes
{
    [TestClass]
    public class MatchTypeResolverTests
    {
        private MatchTypeResolver _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new MatchTypeResolver();
        }

        [TestMethod]
        public void ResolveShouldReturnAny()
        {
            Assert.AreEqual(MatchType.Any, _service.Resolve(Constants.Items.MatchType.Any));
        }

        [TestMethod]
        public void ResolveShouldReturnAll()
        {
            Assert.AreEqual(MatchType.All, _service.Resolve(Constants.Items.MatchType.All));
        }

    }
}
