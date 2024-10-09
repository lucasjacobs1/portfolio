using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Column("community_id")]
        public int CommunityId { get; set; }
        [Column("user_id")]
        public int UserId {  get; set; }    
        public string Content { get; set; } = string.Empty;
        [Column("post_created")]
        public DateTime PostCreated { get; set; }
        public PostModel() { }

    }

}
