using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        /// <summary>
        /// Get a user by identity id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// UserModel
        /// </returns>
        UserModel GetByIdentityId(int identityId);
    }
}
