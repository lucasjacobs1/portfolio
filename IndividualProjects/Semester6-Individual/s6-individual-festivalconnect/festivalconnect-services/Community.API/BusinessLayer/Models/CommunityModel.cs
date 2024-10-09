using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class CommunityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        [Column("community_created")]
        public DateTime CommunityCreated { get; set; }
        [Column("organizer_id")]
        public int OrganizerId { get; set; }
        [Column("member_count")]
        public int MemberCount { get; set; }
        public CommunityModel() { }
    }
}
