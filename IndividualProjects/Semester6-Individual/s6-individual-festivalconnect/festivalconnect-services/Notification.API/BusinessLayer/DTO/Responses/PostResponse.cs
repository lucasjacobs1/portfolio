using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO.Responses
{
    public class PostResponse
    {
        public int Id { get; set; }
        public int CommunityId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime PostCreated { get; set; }
    }
}
