using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
    public class IdentityModel
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        [Column("role_id")]   
        public int RoleId { get; set; }
    }
}
