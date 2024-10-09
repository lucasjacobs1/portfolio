using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repository
{
    public class IdentityRepository: BaseRepository<IdentityModel>, IIdentityRepository
    {
        public IdentityRepository(DatabaseContext db)
            : base(db) { }

        public async Task<IdentityModel> GetIdentityByEmail(string email)
        {
            return await Context.Set<IdentityModel>().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
