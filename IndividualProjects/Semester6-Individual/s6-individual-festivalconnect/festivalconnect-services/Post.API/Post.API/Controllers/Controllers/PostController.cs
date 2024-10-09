using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Post.API.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController: ControllerBase
    {
        private readonly IPostLogic _postService;

        public PostController(IPostLogic postLogic)
        {
            _postService = postLogic ?? throw new ArgumentNullException(nameof(postLogic));
        }

        [HttpGet("GetById/{id}")]
        [Authorize(Roles = "FESTIVALGOER,FESTIVALORGANIZER,ADMIN")]
        public async Task<ActionResult<PostResponse>> GetPostByIdAsync(int id)
        {
            var result = await _postService.GetPostByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetPostsByCommunityId/{id}")]
        [Authorize(Roles = "FESTIVALGOER,FESTIVALORGANIZER,ADMIN")]
        public ActionResult<List<PostResponse>> GetPostsCommunityIdAsync(int id)
        {
            var result = _postService.GetPostsByCommunityId(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "FESTIVALGOER,FESTIVALORGANIZER,ADMIN")]
        public ActionResult<bool> CreatePost([FromBody] CreatePostRequest request)
        {
            var result = _postService.CreatePostRequest(request);
            if (result)
            {
                return Ok(result);
            }
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "FESTIVALGOER,FESTIVALORGANIZER,ADMIN")]
        public ActionResult<bool> UpdatePost([FromBody] UpdatePostRequest request)
        {
            var result = _postService.UpdatePostRequest(request);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "FESTIVALGOER,FESTIVALORGANIZER,ADMIN")]
        public ActionResult<bool> DeletePostById(int id)
        {
            var result =  _postService.DeletePostById(id);
            return Ok(result);
        }

    }
}
