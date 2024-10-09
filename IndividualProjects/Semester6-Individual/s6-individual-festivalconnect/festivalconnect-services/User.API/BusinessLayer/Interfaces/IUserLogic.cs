using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Models;

namespace BusinessLayer.Interfaces
{
    /// <summary>
    /// A service to perform business operations for user management
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Create a user 
        /// </summary>
        /// <param name="request"></param>
        Task RegisterUser(RabbitMessage<UserResponse> request);
        /// <summary>
        /// Get a user by identity id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// UserResponse
        /// </returns>
        Task<UserResponse> GetUserByIdAsync(int identityId);

        /// <summary>
        /// Delete a user 
        /// </summary>
        /// <param name="request"></param>
        Task DeleteUser(RabbitMessage<UserResponse> request);
        /// <summary>
        /// Update a user 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// bool
        /// </returns>
        Task<bool> UpdateUser(UpdateUserRequest request);
    }
}
