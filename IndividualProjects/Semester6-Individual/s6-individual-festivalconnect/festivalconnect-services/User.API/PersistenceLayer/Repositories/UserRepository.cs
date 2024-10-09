using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(DatabaseContext db)
            : base(db) { }

        public UserModel GetByIdentityId(int identityId) =>  Context.Set<UserModel>().Where(x => x.IdentityId == identityId).FirstOrDefault();
    }
}
