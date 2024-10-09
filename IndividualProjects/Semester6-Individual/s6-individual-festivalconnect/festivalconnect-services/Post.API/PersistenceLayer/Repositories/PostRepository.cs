using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using PersistenceLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class PostRepository : BaseRepository<PostModel>, IPostRepository
    {
        public PostRepository(DatabaseContext db)
            : base(db) { }

        public List<PostModel> GetPostsByCommunityId(int communityId)
        {
            List<PostModel> postModels = Context.Set<PostModel>().Where(x => x.CommunityId == communityId).ToList();
            if(postModels != null && postModels.Count > 0)
            {
                return postModels;
            }
            else
            {
                throw new ArgumentException("No posts found from community");
            }
        }
    }
}
