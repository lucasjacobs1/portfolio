using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Column("identity_id")]
        public int IdentityId { get; set; } 
        public string Username { get; set; } = string.Empty;
        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public UserModel() { }
    }
}
