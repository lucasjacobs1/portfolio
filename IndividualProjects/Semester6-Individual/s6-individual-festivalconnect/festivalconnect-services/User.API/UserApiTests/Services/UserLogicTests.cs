using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using BusinessLayer.Logic;
using BusinessLayer.Models;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApiTests.Services
{
    [TestClass]
    public class UserLogicTests
    {
        private Mock<IUserRepository> _userRepository;
        private UserLogic _userLogic;
        private Mock<IMessagingLogic> _messagingLogic;
        private Mock<IDistributedCache> _cache;

        [TestInitialize]
        public void Intialize()
        {
            _userRepository = new Mock<IUserRepository>();
            _messagingLogic = new Mock<IMessagingLogic>();
            _cache = new Mock<IDistributedCache>();

            _userLogic = new UserLogic(_cache.Object, _userRepository.Object);
        }


        [TestMethod]
        public async Task UpdateUser_ExistingUser_SuccessfullyUpdated()
        {
            // Arrange
            var request = new UpdateUserRequest
            {
                IdentityId = 1,
                Username = "newUsername"
            };
            var existingUser = new UserModel { IdentityId = 1, Username = "oldUsername" };
            _userRepository.Setup(repo => repo.GetByIdentityId(request.IdentityId))
                           .Returns(existingUser);
            _userRepository.Setup(repo => repo.Update(It.IsAny<UserModel>()))
                           .Returns(true);

            // Act
            var result = await _userLogic.UpdateUser(request);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(request.Username, existingUser.Username);
            _cache.Verify(c => c.RemoveAsync(It.Is<string>(k => k == $"User_{request.IdentityId}"), default), Times.Once);
        }

        [TestMethod]
        public async Task UpdateUser_NonExistingUser_ThrowsArgumentException()
        {
            // Arrange
            var request = new UpdateUserRequest
            {
                IdentityId = 1,
                Username = "newUsername"
            };
            _userRepository.Setup(repo => repo.GetByIdentityId(request.IdentityId))
                           .Returns((UserModel)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _userLogic.UpdateUser(request));
            _cache.Verify(c => c.RemoveAsync(It.IsAny<string>(), default), Times.Never);
        }

        [TestMethod]
        public async Task UpdateUser_UpdateFails_ThrowsArgumentException()
        {
            // Arrange
            var request = new UpdateUserRequest
            {
                IdentityId = 1,
                Username = "newUsername"
            };
            var existingUser = new UserModel { IdentityId = 1, Username = "oldUsername" };
            _userRepository.Setup(repo => repo.GetByIdentityId(request.IdentityId))
                           .Returns(existingUser);
            _userRepository.Setup(repo => repo.Update(It.IsAny<UserModel>()))
                           .Returns(false);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _userLogic.UpdateUser(request));
            _cache.Verify(c => c.RemoveAsync(It.IsAny<string>(), default), Times.Never);
        }

        [TestMethod]
        public async Task DeleteUser_NonExistingUser_ThrowsArgumentException()
        {
            // Arrange
            var request = new RabbitMessage<UserResponse>
            {
                Data = new UserResponse { IdentityId = 1 }
            };
            _userRepository.Setup(repo => repo.GetByIdentityId(request.Data.IdentityId))
                           .Returns((UserModel)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _userLogic.DeleteUser(request));
            _cache.Verify(c => c.RemoveAsync(It.IsAny<string>(), default), Times.Never);
        }

        [TestMethod]
        public async Task DeleteUser_DeletionFails_ThrowsArgumentException()
        {
            // Arrange
            var request = new RabbitMessage<UserResponse>
            {
                Data = new UserResponse { IdentityId = 1 }
            };
            var existingUser = new UserModel { IdentityId = 1 };
            _userRepository.Setup(repo => repo.GetByIdentityId(request.Data.IdentityId))
                           .Returns(existingUser);
            _userRepository.Setup(repo => repo.Delete(existingUser))
                           .Returns(false);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _userLogic.DeleteUser(request));
            _cache.Verify(c => c.RemoveAsync(It.IsAny<string>(), default), Times.Never);
        }

        [TestMethod]
        public async Task DeleteUser_ExistingUser_SuccessfullyDeleted()
        {
            // Arrange
            var request = new RabbitMessage<UserResponse>
            {
                Data = new UserResponse { IdentityId = 1 }
            };
            var existingUser = new UserModel { IdentityId = 1 };
            _userRepository.Setup(repo => repo.GetByIdentityId(request.Data.IdentityId))
                           .Returns(existingUser);
            _userRepository.Setup(repo => repo.Delete(existingUser))
                           .Returns(true);

            // Act
            await _userLogic.DeleteUser(request);

            // Assert
            _cache.Verify(c => c.RemoveAsync(It.Is<string>(k => k == $"User_{request.Data.IdentityId}"), default), Times.Once);
        }

        [TestMethod]
        public async Task RegisterUser_FailedRegistration_ThrowsArgumentException()
        {
            // Arrange
            var request = new RabbitMessage<UserResponse>
            {
                Data = new UserResponse
                {
                    IdentityId = 1,
                    Username = "username"
                }
            };
            _userRepository.Setup(repo => repo.Create(It.IsAny<UserModel>()))
                          .ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _userLogic.RegisterUser(request));
        }

    }
}
