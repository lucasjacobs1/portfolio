using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface INotificationMembershipRepository: IBaseRepository<NotificationMembershipModel>
    {
        /// <summary>
        /// Get all notifcations members by community id 
        /// </summary>
        /// <param name="communityId"></param>
        /// <returns>
        /// List NotificationMembershipModel
        /// </returns>
        List<NotificationMembershipModel> GetNotificationMembershipModelsByCommunityId(int communityId);

    }
}
