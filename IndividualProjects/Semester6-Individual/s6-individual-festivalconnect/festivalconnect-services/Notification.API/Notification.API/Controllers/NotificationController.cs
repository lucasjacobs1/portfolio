using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController: ControllerBase
    {
        private readonly INotificationLogic _notificationLogic;
        public NotificationController(INotificationLogic notificationLogic)
        {
            _notificationLogic = notificationLogic;
        }

        [HttpGet("GetById/{id}")]
        public  ActionResult<NotificationResponse> GetNotificationByIdAsync(int id)
        {
            var result = _notificationLogic.GetNotificationByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetNotificationsByUserId/{id}")]
        public ActionResult<List<NotificationResponse>> GetNotificationsByUserIdUntillOneMonth(int id)
        {
            var result = _notificationLogic.GetNotificationsByUserIdUntillOneMonth(id);
            return Ok(result);
        }
    }
}
