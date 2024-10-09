namespace BusinessLayer.Logic
{
    using BusinessLayer.DTO.Requests;
    using BusinessLayer.DTO.Responses;
    using BusinessLayer.Interfaces;
    using BusinessLayer.Models;
    using Microsoft.Extensions.Caching.Distributed;
    using System.Text.Json;

    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRespository;
        private readonly IDistributedCache _cache;
        private readonly string _cacheKeyPrefix = "User_";

        public UserLogic(IDistributedCache cache, IUserRepository userRepository)
        {
            _cache = cache;
            _userRespository = userRepository;
        }

        public async Task RegisterUser(RabbitMessage<UserResponse> request)
        {
            UserModel user = new UserModel()
            {
                IdentityId = request.Data.IdentityId,
                RegistrationDate = DateTime.UtcNow,
                Username = request.Data.Username,
                Active = true,
            };
            var created = await _userRespository.Create(user);
            if (!created)
            {
                throw new ArgumentException("Cannot be registered");
            }
        }

        public async Task<UserResponse> GetUserByIdAsync(int identityId)
        {
            string cacheKey = $"{_cacheKeyPrefix}{identityId}";
            // Try to get the user data from the cache
            string? chachedUser = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(chachedUser))
            {
                // Deserialize and return the cached data
                return JsonSerializer.Deserialize<UserResponse>(await _cache.GetStringAsync(cacheKey));
            }
            UserModel user = _userRespository.GetByIdentityId(identityId);
            if (user != null)
            {
                UserResponse userResponse = new UserResponse()
                {
                    Id = user.Id,
                    IdentityId = -1,
                    Username = user.Username,
                    Active = user.Active,
                    RegistrationDate = user.RegistrationDate,
                };

                var cacheEntryOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) // Cache for 5 minutes
                };
                string userJson = JsonSerializer.Serialize(userResponse);
                await _cache.SetStringAsync(cacheKey, userJson, cacheEntryOptions);


                return userResponse;
            }
            else
            {
                throw new ArgumentException("No user with such id.");
            }
        }

        public async Task DeleteUser(RabbitMessage<UserResponse> request)
        {
            UserModel user = _userRespository.GetByIdentityId(request.Data.IdentityId) ?? throw new ArgumentException();
            var isUserDeleted = _userRespository.Delete(user);
            if (!isUserDeleted)
            {
                throw new ArgumentException("Could not be deleted");
            }

            // Remove the user from the cache
            var cacheKey = $"User_{request.Data.IdentityId}";
            await _cache.RemoveAsync(cacheKey);

        }

        public async Task<bool> UpdateUser(UpdateUserRequest request)
        {
            UserModel existing = _userRespository.GetByIdentityId(request.IdentityId);
            if (existing == null)
            {
                throw new ArgumentException("User can not be found");
            }

            existing.Username = request.Username;

            var result = _userRespository.Update(existing);
            if (!result)
            {
                throw new ArgumentException("User is not updated.");
            }

            // Remove the user from the cache
            var cacheKey = $"User_{request.IdentityId}";
            await _cache.RemoveAsync(cacheKey);

            return true;
        }
    }
}
