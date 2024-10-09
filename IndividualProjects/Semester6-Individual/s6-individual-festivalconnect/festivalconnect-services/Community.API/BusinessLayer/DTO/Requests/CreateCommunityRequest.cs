using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO.Requests
{
    public class CreateCommunityRequest
    {
        public string CommunityName { get; set; } = string.Empty;
        public string CommunityDescription { get; set; } = string.Empty;
        public int OrganizerId { get; set; }
    }

}
