using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        // Define DbSet properties for your entities
        public DbSet<NotificationModel> Notifications { get; set; }

        public DbSet<NotificationMembershipModel> NotificationMembership { get; set; }
    }
}
