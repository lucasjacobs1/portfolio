using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Entities;

namespace PersistenceLayer.Repositories
{
    public class NotificationRepository : BaseRepository<NotificationModel>, INotificationRepository
    {
        public NotificationRepository(DatabaseContext db)
            : base(db) { }


        public List<NotificationModel> GetNotificationsByUserIdUptillOneMonthAgo(int userId)
        {
            DateTime oneMonthAgo = DateTime.UtcNow.AddMonths(-1);
            List<NotificationModel> notificationModels = Context.Set<NotificationModel>()
                .Where(x => x.UserId == userId && x.Created > oneMonthAgo)
                .OrderBy(x => x.Created)
                .ToList();
            if (notificationModels != null && notificationModels.Count > 0)
            {
                return notificationModels;
            }
            else
            {
                throw new ArgumentException("No notifications found for user");
            }
        }

    }
}
