using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPostRepository : IBaseRepository<PostModel>
    {
        /// <summary>
        /// Get all posts items by community id
        /// </summary>
        /// <param name="communityId"></param>
        /// <returns>
        /// List of PostResponse
        /// </returns>
        List<PostModel> GetPostsByCommunityId(int communityId);
    }
}
