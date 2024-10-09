using LogicLayer.CustomExceptions;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LoginAdmin
    {
        private ILoginService _LoginAdmin;
        public LoginAdmin(ILoginService loginAdmin)
        {
            _LoginAdmin = loginAdmin;
        }

        public bool ValidateLogin(Login login)
        {
            login.Password = UserHelper.CreateMD5(login.Password);
            if (_LoginAdmin.ValidateLogin(login))
            {
                return true;
            }
            else
            {
                throw new InvalidLoginInputException("Email or password wrong");
            }
        }
    }
}
