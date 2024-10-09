using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public int IdentityId { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public UserResponse() { }
    }
}
