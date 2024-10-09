using BusinessLayer.DTO.Requests;
using BusinessLayer.Interfaces;
using BusinessLayer.Logic;
using BusinessLayer.Models;
using Moq;

namespace PostApiTests.Services
{
    [TestClass]
    public class PostLogicTests
    {
        private Mock<IPostRepository> _postRepository;
        private PostLogic _postLogic;
        //private Mock<IMessagingLogic> _messagingLogic;

        [TestInitialize]
        public void Intialize()
        {
            //_messagingLogic = new Mock<IMessagingLogic>();
            _postRepository = new Mock<IPostRepository>();
            _postLogic = new PostLogic(_postRepository.Object);
        }

        [TestMethod]
        public async Task GetPostByIdAsync_WithValidId_ReturnsPostResponse()
        {
            // Arrange
            int postId = 1;
            PostModel mockPost = new PostModel
            {
                Id = postId,
                CommunityId = 1,
                Content = "Test content",
                PostCreated = DateTime.UtcNow,
                UserId = 1
            };
            _postRepository.Setup(repo => repo.GetById(postId)).Returns(mockPost);

            // Act
            var result = await _postLogic.GetPostByIdAsync(postId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(postId, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetPostByIdAsync_WithInvalidId_ThrowsArgumentException()
        {
            // Arrange
            int invalidPostId = -1;
            _postRepository.Setup(repo => repo.GetById(invalidPostId)).Returns((PostModel)null);

            // Act
            var result = await _postLogic.GetPostByIdAsync(invalidPostId);

            // Assert
            Assert.IsNull(result);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetPostByIdAsync_WithNonexistentId_ReturnsNull()
        {
            // Arrange
            int nonExistentPostId = 999;
            _postRepository.Setup(repo => repo.GetById(nonExistentPostId)).Returns((PostModel)null);

            // Act
            var result = await _postLogic.GetPostByIdAsync(nonExistentPostId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetPostsByCommunityId_ValidId_ReturnsPostResponses()
        {
            // Arrange
            int validCommunityId = 1;
            List<PostModel> mockPostModels = new List<PostModel>
            {
                new PostModel { Id = 1, CommunityId = validCommunityId, Content = "Content 1", PostCreated = DateTime.UtcNow, UserId = 1 },
                new PostModel { Id = 2, CommunityId = validCommunityId, Content = "Content 2", PostCreated = DateTime.UtcNow, UserId = 2 }
            };
            _postRepository.Setup(repo => repo.GetPostsByCommunityId(validCommunityId)).Returns(mockPostModels);

            // Act
            var result = _postLogic.GetPostsByCommunityId(validCommunityId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mockPostModels.Count, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No Posts found")]
        public void GetPostsByCommunityId_ValidId_NoPostsFound_ThrowsArgumentException()
        {
            // Arrange
            int validCommunityId = 1;
            _postRepository.Setup(repo => repo.GetPostsByCommunityId(validCommunityId)).Returns((List<PostModel>)null);

            // Act
            var result = _postLogic.GetPostsByCommunityId(validCommunityId);

            // Assert
            // ArgumentException thrown with message
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid community ID")]
        public void GetPostsByCommunityId_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            int invalidCommunityId = 0; // Invalid community ID

            // Act
            var result = _postLogic.GetPostsByCommunityId(invalidCommunityId);

            // Assert
            // ArgumentException thrown with message
        }

        [TestMethod]
        public void CreatePostRequest_ValidInput_ReturnsTrue()
        {
            // Arrange
            var createPostRequest = new CreatePostRequest
            {
                CommunityId = 1,
                Content = "Test content",
                UserId = 1
            };
            _postRepository.Setup(repo => repo.Create(It.IsAny<PostModel>())).Returns(true);

            // Act
            var result = _postLogic.CreatePostRequest(createPostRequest);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "CreatePostRequest cannot be null.")]
        public void CreatePostRequest_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            CreatePostRequest createPostRequest = null;

            // Act
            var result = _postLogic.CreatePostRequest(createPostRequest);

            // Assert
            // ArgumentNullException thrown with message
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Could not be created.")]
        public void CreatePostRequest_RepositoryFails_ThrowsInvalidOperationException()
        {
            // Arrange
            var createPostRequest = new CreatePostRequest
            {
                CommunityId = 1,
                Content = "Test content",
                UserId = 1
            };
            _postRepository.Setup(repo => repo.Create(It.IsAny<PostModel>())).Returns(false);

            // Act
            var result = _postLogic.CreatePostRequest(createPostRequest);

            // Assert
            // InvalidOperationException thrown with message
        }

        [TestMethod]
        public void UpdatePostRequest_ValidInput_ReturnsTrue()
        {
            // Arrange
            var updatePostRequest = new UpdatePostRequest
            {
                PostId = 1,
                Content = "Updated content"
            };
            var existingPost = new PostModel
            {
                Id = updatePostRequest.PostId,
                Content = "Original content"
            };
            _postRepository.Setup(repo => repo.GetById(updatePostRequest.PostId)).Returns(existingPost);
            _postRepository.Setup(repo => repo.Update(existingPost)).Returns(true);

            // Act
            var result = _postLogic.UpdatePostRequest(updatePostRequest);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(updatePostRequest.Content, existingPost.Content); // Verify that content is updated
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "UpdatePostRequest cannot be null.")]
        public void UpdatePostRequest_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            UpdatePostRequest updatePostRequest = null;

            // Act
            var result = _postLogic.UpdatePostRequest(updatePostRequest);

            // Assert
            // ArgumentNullException thrown with message
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cannot find the post")]
        public void UpdatePostRequest_PostNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            var updatePostRequest = new UpdatePostRequest
            {
                PostId = 999, // Non-existent post ID
                Content = "Updated content"
            };
            _postRepository.Setup(repo => repo.GetById(updatePostRequest.PostId)).Returns((PostModel)null);

            // Act
            var result = _postLogic.UpdatePostRequest(updatePostRequest);

            // Assert
            // InvalidOperationException with message thrown
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Not able to update")]
        public void UpdatePostRequest_RepositoryFails_ThrowsInvalidOperationException()
        {
            // Arrange
            var updatePostRequest = new UpdatePostRequest
            {
                PostId = 1,
                Content = "Updated content"
            };
            var existingPost = new PostModel
            {
                Id = updatePostRequest.PostId,
                Content = "Original content"
            };
            _postRepository.Setup(repo => repo.GetById(updatePostRequest.PostId)).Returns(existingPost);
            _postRepository.Setup(repo => repo.Update(existingPost)).Returns(false); // Simulate repository failure

            // Act
            var result = _postLogic.UpdatePostRequest(updatePostRequest);

            // Assert
            // InvalidOperationException with message thrown
        }

        [TestMethod]
        public void DeletePostById_ValidId_ReturnsTrue()
        {
            // Arrange
            int validPostId = 1;
            var existingPost = new PostModel
            {
                Id = validPostId
            };
            _postRepository.Setup(repo => repo.GetById(validPostId)).Returns(existingPost);
            _postRepository.Setup(repo => repo.Delete(existingPost)).Returns(true);

            // Act
            var result = _postLogic.DeletePostById(validPostId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Post cannot be found with specified id")]
        public void DeletePostById_NoExsistingId_ThrowsInvalidOperationException()
        {
            // Arrange
            int nonExistentPostId = 999; // Non-existent post ID
            _postRepository.Setup(repo => repo.GetById(nonExistentPostId)).Returns((PostModel)null);

            // Act
            var result = _postLogic.DeletePostById(nonExistentPostId);

            // Assert
            // InvalidOperationException thrown with message
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cannot be deleted")]
        public void DeletePostById_RepositoryFails_ThrowsInvalidOperationException()
        {
            // Arrange
            int validPostId = 1;
            var existingPost = new PostModel
            {
                Id = validPostId
            };
            _postRepository.Setup(repo => repo.GetById(validPostId)).Returns(existingPost);
            _postRepository.Setup(repo => repo.Delete(existingPost)).Returns(false); // failure of database

            // Act
            var result = _postLogic.DeletePostById(validPostId);

            // Assert
            // InvalidOperationException is thrown because repo fails
        }
    }
}
