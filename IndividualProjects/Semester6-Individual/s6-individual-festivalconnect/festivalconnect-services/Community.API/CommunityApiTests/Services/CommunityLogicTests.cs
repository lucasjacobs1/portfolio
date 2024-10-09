using BusinessLayer.Interfaces;
using BusinessLayer.Logic;
using BusinessLayer.Models;
using Moq;

namespace CommunityApiTests.Services
{
    [TestClass]
    public class CommunityLogicTests
    {
        private Mock<ICommunityRepository> _communityRepository;
        private CommunityLogic _communityLogic;
        private Mock<IMessagingLogic> _messagingLogic;

        [TestInitialize]
        public void Intialize()
        {
            _communityRepository = new Mock<ICommunityRepository>();
            _messagingLogic = new Mock<IMessagingLogic>();
            _communityLogic = new CommunityLogic(_communityRepository.Object, _messagingLogic.Object);
        }

        [TestMethod]
        public void DeleteCommunity_ExistingCommunity_DeletesCommunity()
        {
            // Arrange
            int communityId = 1;
            var communityModel = new CommunityModel { Id = communityId, Name = "Test Community" };
            _communityRepository.Setup(r => r.GetById(communityId)).Returns(communityModel);
            _communityRepository.Setup(r => r.Delete(communityModel)).Returns(true);

            // Act
            var result = _communityLogic.DeleteCommunity(communityId);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DeleteCommunity_NonExistingCommunity_ThrowsArgumentException()
        {
            // Arrange
            int communityId = 999; // Assuming this id doesn't exist
            _communityRepository.Setup(r => r.GetById(communityId)).Returns((CommunityModel)null);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _communityLogic.DeleteCommunity(communityId));
        }

        [TestMethod]
        public void DeleteCommunity_FailedToDelete_ThrowsArgumentException()
        {
            // Arrange
            int communityId = 1;
            var communityModel = new CommunityModel { Id = communityId, Name = "Test Community" };
            _communityRepository.Setup(r => r.GetById(communityId)).Returns(communityModel);
            _communityRepository.Setup(r => r.Delete(communityModel)).Returns(false);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _communityLogic.DeleteCommunity(communityId));
        }

    }
}
