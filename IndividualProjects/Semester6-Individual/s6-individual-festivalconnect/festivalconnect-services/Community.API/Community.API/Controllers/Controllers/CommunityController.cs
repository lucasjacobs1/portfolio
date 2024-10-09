using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Community.API.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommunityController: ControllerBase
    {
        private readonly ICommunityLogic _communityLogic;
        public CommunityController(ICommunityLogic communityLogic)
        {
            _communityLogic = communityLogic ?? throw new ArgumentNullException(nameof(communityLogic));
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<CommunityResponse> GetCommunityByIdAsync(int id)
        {
            var result =  _communityLogic.GetCommunityByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<bool> CreateCommunity([FromBody]CreateCommunityRequest request)
        {
            var result = _communityLogic.CreateCommunity(request);
            if (result)
            {
                return Ok(result);
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult<bool> UpdateCommunity([FromBody]UpdateCommunityRequest request)
        {
            var result = _communityLogic.UpdateCommunity(request);
            return Ok(result);  
        }
    }
}
