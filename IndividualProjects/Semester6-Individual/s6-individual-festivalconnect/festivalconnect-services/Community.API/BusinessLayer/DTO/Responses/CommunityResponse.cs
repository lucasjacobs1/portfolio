using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO.Responses
{
    public class CommunityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public CommunityResponse() { }
    }
}
