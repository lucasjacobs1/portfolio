using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UserService.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userService;

        public UserController(IUserLogic userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("GetByIdentityId")]
        [Authorize(Roles = "FESTIVALGOER,FESTIVALORGANIZER,ADMIN")]
        public async Task<ActionResult<UserResponse>> GetUserByIdentityIdAsync()
        {
            try
            {
                var userIdentity = HttpContext.User.Identity as ClaimsIdentity;
                var idClaim = userIdentity.FindFirst("id");
                var id = Convert.ToInt32(idClaim.Value);

                var result = await _userService.GetUserByIdAsync(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Roles = "FESTIVALGOER,FESTIVALORGANIZER,ADMIN")]
        public ActionResult<bool> UpdateUser([FromBody] UpdateUserRequest request)
        {
            try
            {
                var userIdentity = HttpContext.User.Identity as ClaimsIdentity;
                var idClaim = userIdentity.FindFirst("id");
                var id = Convert.ToInt32(idClaim.Value);
                request.IdentityId = id;
                var result = _userService.UpdateUser(request);
                return Ok(result.Result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
