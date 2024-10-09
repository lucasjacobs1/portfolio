using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Group_Project_Website.Logic
{
    public class LogInHandler
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

        public LogInHandler()
        { }
        public LogInHandler(string email, string Password)
        {
            email = this.email;
            Password = this.password;
        }
    }
}
