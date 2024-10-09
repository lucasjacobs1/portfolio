using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface INotificationRepository : IBaseRepository<NotificationModel>
    {
        /// <summary>
        /// Get all notifcations by user id within a time period of one month
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// List NotificationModel
        /// </returns>
        List<NotificationModel> GetNotificationsByUserIdUptillOneMonthAgo(int userId);   
    }
}
