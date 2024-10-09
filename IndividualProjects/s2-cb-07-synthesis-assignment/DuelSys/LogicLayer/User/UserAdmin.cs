using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.CustomExceptions;

namespace LogicLayer
{
    public class UserAdmin
    {
        private IUserService _userAdmin;

        public UserAdmin(IUserService userAdmin)
        {
            _userAdmin = userAdmin;
        }


        public void AddUser(User user)
        {
            if (user.FirstName.Length < 2 || user.FirstName.Length >= 30)
                throw new InvalidUserInputException("First name must be between 2 and 30 characters");
            
            if (user.LastName.Length < 2 || user.LastName.Length >= 30)
                throw new InvalidUserInputException("Last name must be between 2 and 30 characters");
            
            if (!UserHelper.ValidateEmail(user.Email))
                throw new InvalidUserInputException("Email is not correct");

            if (_userAdmin.CheckEmailExists(user.Email))
                throw new InvalidUserInputException("This email already exists");
       
            if(user.Password.Length < 4 && user.Password.Length > 20)
                throw new InvalidUserInputException("Password must be between 4-30 characters");
            
            user.FirstName = user.FirstName.Substring(0, 1).ToUpper() + user.FirstName.Substring(1);
            user.LastName = user.LastName.Substring(0, 1).ToUpper() + user.LastName.Substring(1);
            _userAdmin.AddUser(new User(user.FirstName, user.LastName, user.Email, UserHelper.CreateMD5(user.Password), 1));
        }

        public User GetUserByEmail(string email)
        {
            return _userAdmin.GetUserByEmail(email);
        }

        public User GetUserById(int id)
        {
            return _userAdmin.GetUserById(id);  
        }
        
    }
}

