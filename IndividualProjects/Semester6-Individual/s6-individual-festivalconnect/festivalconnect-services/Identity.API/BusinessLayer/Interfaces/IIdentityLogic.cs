using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IIdentityLogic
    {
        /// <summary>
        /// Register a user  
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// RegistrationResponse
        /// </returns>
        Task<RegistrationResponse> RegisterUserAsync(CreateRegisterUserRequest request);
        /// <summary>
        /// Login  
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns>
        /// LoginResponse
        /// </returns>
        Task<LoginResponse> LoginUserAsyc(CreateLoginRequest loginRequest);

        /// <summary>
        /// Delete a user 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>
        /// bool
        /// </returns>
        Task<bool> DeleteUser(string email);
    }
}
