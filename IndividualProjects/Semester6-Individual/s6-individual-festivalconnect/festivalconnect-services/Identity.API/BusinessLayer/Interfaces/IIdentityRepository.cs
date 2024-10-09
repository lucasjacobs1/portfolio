using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IIdentityRepository : IBaseRepository<IdentityModel>
    {
        Task<IdentityModel> GetIdentityByEmail(string email);
    }
}
