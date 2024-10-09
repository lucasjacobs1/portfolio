using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class Login
    {
        private string email;
        private string password;

        #region Properties
        [Required]
        public string Email { get { return email; } set { email = value; } }
        [Required]
        public string Password { get { return password; } set { password = value; } }
        #endregion

        public Login() { }
        public Login(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
