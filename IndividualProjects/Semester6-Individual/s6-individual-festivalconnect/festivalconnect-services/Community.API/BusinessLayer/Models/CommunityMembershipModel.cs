using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class CommunityMembershipModel
    {
        public CommunityMembershipModel() { }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommunityId { get; set; }
        public DateTime JoinedDate { get; set; }
        public int MessagesSend { get; set; }
    }
}
