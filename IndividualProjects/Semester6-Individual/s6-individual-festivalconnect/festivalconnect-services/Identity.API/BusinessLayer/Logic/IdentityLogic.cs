using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Logic
{
    public class IdentityLogic : IIdentityLogic
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IConfiguration _configuration;
        private readonly IMessagingLogic _messagingLogic;
        public IdentityLogic(IIdentityRepository identityRepository, IConfiguration configuration, IMessagingLogic messagingLogic)
        {
            _identityRepository = identityRepository;
            _configuration = configuration;
            _messagingLogic = messagingLogic;
        }

        public async Task<LoginResponse> LoginUserAsyc(CreateLoginRequest loginRequest)
        {
            var getUser = await FindIdentityByEmail(loginRequest.Email!);
            if (getUser == null) return new LoginResponse(false, "User not found");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginRequest.Password, getUser.Password);
            if (checkPassword)
                return new LoginResponse(true, "Login Succesfully", GenerateJWTToken(getUser));
            else
                return new LoginResponse(false, "Invalid credentials");
        }

        private string GenerateJWTToken(IdentityModel getUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT-KEY"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim("id", getUser.Id.ToString()),
                new Claim("email", getUser.Email!),
                new Claim("roles", Enum.GetName(typeof(RoleEnum), (RoleEnum)getUser.RoleId))
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegistrationResponse> RegisterUserAsync(CreateRegisterUserRequest request)
        {
            var getUser = await FindIdentityByEmail(request.Email!);
            if (getUser != null)
                return new RegistrationResponse(false, "Email Allready Exist.");

            IdentityModel identityModel = new IdentityModel()
            {
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = request.RoleId
            };
            var registered = _identityRepository.Create(identityModel);
            if (!registered)  return new RegistrationResponse(false, "Could not be registered");
            var getRegisteredUser = await FindIdentityByEmail(request.Email!);

            _messagingLogic.Publish("CreateUser", "CreateUser", new RabbitMessage<UserResponse>()
            {
                Data = new UserResponse()
                {
                    IdentityId = getRegisteredUser.Id,
                    Username = request.Username
                }
            });
            return new RegistrationResponse(true, "Registration completed");
        }

        private async Task<IdentityModel> FindIdentityByEmail(string email) =>
            await _identityRepository.GetIdentityByEmail(email);

        public async Task<bool> DeleteUser(string email)
        {
            IdentityModel identity = await FindIdentityByEmail(email);
            if (identity == null) { throw new ArgumentException(); }

            _messagingLogic.Publish("DeleteUser", "DeleteUser", new RabbitMessage<UserResponse>()
            {
                Data = new UserResponse()
                {
                    RegistrationDate = DateTime.Now,
                    IdentityId = identity.Id,
                }
            });

            var isIdentityDeleted = await _identityRepository.DeleteAsync(identity);
            if (!isIdentityDeleted)
            {
                throw new ArgumentException();
            }
            return true;
        }

    }
}
