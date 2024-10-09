using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using PersistenceLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class CommunityRepository : BaseRepository<CommunityModel>, ICommunityRepository
    {
        public CommunityRepository(DatabaseContext db)
            : base(db) { }

    }
}
