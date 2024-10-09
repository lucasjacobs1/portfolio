using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using BusinessLayer.Logic;
using BusinessLayer.Models;
using Microsoft.Extensions.Configuration;
using Moq;

namespace IdentityApiTests.Services
{
    [TestClass]
    public class IdentityLogicTests
    {
        private Mock<IIdentityRepository> _identityRepository;
        private IdentityLogic _identityLogic;
        private Mock<IMessagingLogic> _messagingLogic;
        private Mock<IConfiguration> _configuration;
        [TestInitialize]
        public void Intialize()
        {
            _identityRepository = new Mock<IIdentityRepository>();
            _messagingLogic = new Mock<IMessagingLogic>();
            _configuration = new Mock<IConfiguration>();
            _identityLogic = new IdentityLogic(_identityRepository.Object, _configuration.Object, _messagingLogic.Object);

        }

        [TestMethod]
        public async Task LoginUserAsync_UserNotFound_ReturnsUserNotFoundResponse()
        {
            // Arrange
            var loginRequest = new CreateLoginRequest { Email = "test@example.com", Password = "password" };
            _identityRepository.Setup(repo => repo.GetIdentityByEmail(It.IsAny<string>())).ReturnsAsync((IdentityModel)null);

            // Act
            var result = await _identityLogic.LoginUserAsyc(loginRequest);

            // Assert
            Assert.IsFalse(result.Flag);
            Assert.AreEqual("User not found", result.Message);
        }

        [TestMethod]
        public async Task LoginUserAsync_InvalidPassword_ReturnsInvalidCredentialsResponse()
        {
            // Arrange
            var loginRequest = new CreateLoginRequest { Email = "test@example.com", Password = "wrongpassword" };
            var user = new IdentityModel { Email = "test@example.com", Password = BCrypt.Net.BCrypt.HashPassword("correctpassword") };
            _identityRepository.Setup(repo => repo.GetIdentityByEmail(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _identityLogic.LoginUserAsyc(loginRequest);

            // Assert
            Assert.IsFalse(result.Flag);
            Assert.AreEqual("Invalid credentials", result.Message);
        }

        [TestMethod]
        public async Task LoginUserAsync_ValidCredentials_ReturnsSuccessResponseWithToken()
        {
            // Arrange
            var loginRequest = new CreateLoginRequest { Email = "test@example.com", Password = "correctpassword" };
            var user = new IdentityModel { Id = 1, Email = "test@example.com", Password = BCrypt.Net.BCrypt.HashPassword("correctpassword"), RoleId = 1 };
            _identityRepository.Setup(repo => repo.GetIdentityByEmail(It.IsAny<string>())).ReturnsAsync(user);
            _configuration.Setup(config => config["JWT-KEY"]).Returns("my-32-character-ultra-secure-and-ultra-long-secret");
            _configuration.Setup(config => config["Jwt:Issuer"]).Returns("your-issuer");
            _configuration.Setup(config => config["Jwt:Audience"]).Returns("your-audience");

            // Act
            var result = await _identityLogic.LoginUserAsyc(loginRequest);

            // Assert
            Assert.IsTrue(result.Flag);
            Assert.AreEqual("Login Succesfully", result.Message);
            Assert.IsFalse(string.IsNullOrEmpty(result.Token));
        }

        [TestMethod]
        public async Task RegisterUserAsync_EmailAlreadyExists_ReturnsErrorResponse()
        {
            // Arrange
            var request = new CreateRegisterUserRequest
            {
                Email = "existing@example.com",
                Password = "password",
                RoleId = 1,
                Username = "username"
            };
            _identityRepository.Setup(repo => repo.GetIdentityByEmail(It.IsAny<string>()))
                .ReturnsAsync(new IdentityModel());

            // Act
            var result = await _identityLogic.RegisterUserAsync(request);

            // Assert
            Assert.IsFalse(result.Flag);
            Assert.AreEqual("Email Allready Exist.", result.Message);
        }

        [TestMethod]
        public async Task RegisterUserAsync_RegistrationFails_ReturnsErrorResponse()
        {
            // Arrange
            var request = new CreateRegisterUserRequest
            {
                Email = "new@example.com",
                Password = "password",
                RoleId = 1,
                Username = "username"
            };
            _identityRepository.Setup(repo => repo.GetIdentityByEmail(It.IsAny<string>()))
                .ReturnsAsync((IdentityModel)null);
            _identityRepository.Setup(repo => repo.Create(It.IsAny<IdentityModel>()))
                .Returns(false);

            // Act
            var result = await _identityLogic.RegisterUserAsync(request);

            // Assert
            Assert.IsFalse(result.Flag);
            Assert.AreEqual("Could not be registered", result.Message);
        }

    }
}
