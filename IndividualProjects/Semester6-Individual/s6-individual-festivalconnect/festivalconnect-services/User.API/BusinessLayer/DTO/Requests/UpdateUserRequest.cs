using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO.Requests
{
    public class UpdateUserRequest
    {
        public int IdentityId { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
