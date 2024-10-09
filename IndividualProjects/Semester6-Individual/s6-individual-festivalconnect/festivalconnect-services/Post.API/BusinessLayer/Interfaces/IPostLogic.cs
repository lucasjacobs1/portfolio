using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPostLogic
    {
        /// <summary>
        /// Get a post by id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>
        /// PostResponse
        /// </returns>
        Task<PostResponse> GetPostByIdAsync(int postId);
        /// <summary>
        /// Get all posts by community id
        /// </summary>
        /// <param name="communityId"></param>
        /// <returns>
        /// List PostResponse
        /// </returns>
        List<PostResponse> GetPostsByCommunityId(int communityId);
        /// <summary>
        /// Create post
        /// </summary>
        /// <param name="createPostRequest"></param>
        /// <returns>
        /// bool
        /// </returns>
        bool CreatePostRequest(CreatePostRequest createPostRequest);
        /// <summary>
        /// Update a post
        /// </summary>
        /// <param name="updatePostRequest"></param>
        /// <returns>
        /// bool
        /// </returns>
        bool UpdatePostRequest(UpdatePostRequest updatePostRequest);
        /// <summary>
        /// delete a post by Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>
        /// bool
        /// </returns>
        bool DeletePostById(int postId);
    }
}
