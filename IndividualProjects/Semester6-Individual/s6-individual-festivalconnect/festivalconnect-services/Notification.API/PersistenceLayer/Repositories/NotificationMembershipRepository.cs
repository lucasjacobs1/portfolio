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
    public class NotificationMembershipRepository: BaseRepository<NotificationMembershipModel>, INotificationMembershipRepository
    {

        public NotificationMembershipRepository(DatabaseContext db)
            : base(db) {
        }

        public List<NotificationMembershipModel> GetNotificationMembershipModelsByCommunityId(int communityId)
        {
            List<NotificationMembershipModel> notificationMembershipModels = Context.Set<NotificationMembershipModel>()
                .Where(x => x.CommunityId == communityId)
                .ToList();
            if (notificationMembershipModels != null && notificationMembershipModels.Count > 0)
            {
                return notificationMembershipModels;
            }
            else
            {
                throw new ArgumentException("No notification members found.");
            }
        }
    }
}
