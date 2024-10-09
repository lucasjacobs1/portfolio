using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System.Runtime.CompilerServices;

namespace BusinessLayer.Logic
{
    public class PostLogic : IPostLogic
    {
        private readonly IPostRepository _postRespository;

        public PostLogic(IPostRepository postRepository)
        {
            _postRespository = postRepository;
        }

        public async Task<PostResponse> GetPostByIdAsync(int postId)
        {
            PostModel post = _postRespository.GetById(postId);
            if (post != null)
            {
                PostResponse postResponse = new PostResponse()
                {
                    Id = postId,
                    CommunityId = post.CommunityId,
                    Content = post.Content,
                    PostCreated = post.PostCreated,
                    UserId = post.UserId,
                };
                return postResponse;
            }
            else { throw new ArgumentException("No post with such id."); }
        }

        public List<PostResponse> GetPostsByCommunityId(int communityId)
        {
            List<PostModel> postModelsByCommunityId = _postRespository.GetPostsByCommunityId(communityId);
            List<PostResponse> posts = new List<PostResponse>();
            if(postModelsByCommunityId != null)
            {
                foreach(var postModel in postModelsByCommunityId)
                {
                    PostResponse postsResponse = new PostResponse()
                    {
                        Id = postModel.Id,
                        CommunityId = postModel.CommunityId,
                        Content = postModel.Content,
                        PostCreated = postModel.PostCreated,
                        UserId = postModel.UserId,

                    };
                    posts.Add(postsResponse);
                }
                return posts;
            }
            else { throw new ArgumentException("No Posts found"); }
        }

        public bool CreatePostRequest(CreatePostRequest createPostRequest)
        {
            // Validate createPostRequest object
            if (createPostRequest == null)
            {
                throw new ArgumentNullException(nameof(createPostRequest), "CreatePostRequest cannot be null.");
            }

            //Consistent TimeZone across all application :UTC
            DateTime dateTime = DateTime.UtcNow;

            PostModel postModel = new PostModel()
            {
                CommunityId = createPostRequest.CommunityId,
                Content = createPostRequest.Content,
                PostCreated = dateTime,
                UserId = createPostRequest.UserId,
            };

            var created = _postRespository.Create(postModel);

            if (!created) { throw new InvalidOperationException("Could not be created."); }

            /*_messagingLogic.Publish("CreatePost", "CreatePost", new RabbitMessage<PostResponse>()
            {
                Data = new PostResponse()
                {
                    CommunityId = postModel.CommunityId,
                    Content = postModel.Content,
                    PostCreated = postModel.PostCreated,
                    UserId = postModel.UserId,
                }
            });*/

            return true;
        }

        public bool UpdatePostRequest(UpdatePostRequest updatePostRequest)
        {
            // Validate updatePostRequest object
            if (updatePostRequest == null)
            {
                throw new ArgumentNullException(nameof(updatePostRequest), "UpdatePostRequest cannot be null.");
            }

            //Validate that the post exist
            PostModel postModel = _postRespository.GetById(updatePostRequest.PostId);
            if (postModel == null)
            {
                throw new InvalidOperationException("Cannot find the post");
            }
            //Consistent TimeZone across all application :UTC
            DateTime dateTime = DateTime.UtcNow;

            postModel.PostCreated = dateTime;
            postModel.Content = updatePostRequest.Content;

            var updatePost = _postRespository.Update(postModel);
            if (!updatePost) { throw new InvalidOperationException("Not able to update"); }
            return true;
        }

        public bool DeletePostById(int postId) 
        {
            PostModel postModel = _postRespository.GetById(postId);
            if(postModel != null)
            {
                var postDeletion = _postRespository.Delete(postModel);
                if(!postDeletion) { throw new InvalidOperationException("Cannot be deleted"); }
                return true;
            }
            else
            {
                throw new InvalidOperationException("Post cannot be found with specified id");
            }
        }
    }
}
