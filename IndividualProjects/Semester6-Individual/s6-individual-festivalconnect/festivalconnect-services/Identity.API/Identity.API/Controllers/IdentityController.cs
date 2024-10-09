using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController: ControllerBase
    {
        private readonly IIdentityLogic _identityLogic;

        public IdentityController(IIdentityLogic identityLogic)
        {
            _identityLogic = identityLogic;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginUser(CreateLoginRequest request)
        {
            try
            {
                var result = await _identityLogic.LoginUserAsyc(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex);
            }

        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> RegisterUser(CreateRegisterUserRequest createRegisterUserRequest)
        {
            var result = await _identityLogic.RegisterUserAsync(createRegisterUserRequest);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "FESTIVALGOER,FESTIVALORGANIZER,ADMIN")]
        public async Task<ActionResult<bool>> DeleteUser()
        {
            try
            {
                var email = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                if (email == null) return BadRequest();
                var result = await _identityLogic.DeleteUser(email);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
