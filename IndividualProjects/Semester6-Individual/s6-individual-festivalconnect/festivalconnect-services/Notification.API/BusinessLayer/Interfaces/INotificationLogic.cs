using BusinessLayer.DTO.Responses;
using BusinessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface INotificationLogic
    {
        /// <summary>
        /// Get a notifcation by id
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns>
        /// NotificationResponse
        /// </returns>
        NotificationResponse GetNotificationByIdAsync(int notificationId);
        /// <summary>
        /// Get all notifcations by user id from uptill a month ago 
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns>
        /// NotificationResponse
        /// </returns>
        List<NotificationResponse> GetNotificationsByUserIdUntillOneMonth(int userId);
    }
}
