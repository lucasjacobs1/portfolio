using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Logic
{
    public class NotificationLogic: INotificationLogic
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationMembershipRepository _notificationMembershipRepository;
        private readonly IMessagingLogic _messagingLogic;
        public NotificationLogic(INotificationRepository notificationRepository, IMessagingLogic messagingLogic, INotificationMembershipRepository notificationMembershipRepository) 
        {
            _notificationRepository = notificationRepository;
            _messagingLogic = messagingLogic;
            _notificationMembershipRepository = notificationMembershipRepository;
            _messagingLogic.Subscribe<RabbitMessage<PostResponse>>(
                "CreatePost",
                "CreatePost",
                "CreatePost",
                NotifyCreatePost);
        }

        // Method to be called during application startup to ensure subscription
        public void Initialize()
        {
            _messagingLogic.Publish("CreatePost", "CreatePost", new RabbitMessage<PostResponse>()
            {
                Data = new PostResponse()
                {
                    CommunityId = 0,
                    Content = "ters",
                    PostCreated = DateTime.UtcNow,
                    UserId = 0,
                }
            });
        }

        // Method to subscribe to the "CreatePost" message queue
        public void SubscribeToCreatePostQueue()
        {
            _messagingLogic.Subscribe<RabbitMessage<PostResponse>>(
                "CreatePost",
                "CreatePost",
                "CreatePost",
                NotifyCreatePost
            );
        }


        public NotificationResponse GetNotificationByIdAsync(int notificationId)
        {
            NotificationModel notification = _notificationRepository.GetById(notificationId);
            if (notification != null)
            {
                NotificationResponse notificationResponse = new NotificationResponse()
                {
                    Id = notification.Id,
                    Message = notification.Message,
                    UserId = notification.UserId,
                    Created = notification.Created
                };
                return notificationResponse;
            }
            else { throw new ArgumentException("No notification with such id."); }
        }

        public List<NotificationResponse> GetNotificationsByUserIdUntillOneMonth(int userId)
        {
            List<NotificationModel> notifications = _notificationRepository.GetNotificationsByUserIdUptillOneMonthAgo(userId);
            if (notifications != null)
            {
                List<NotificationResponse> result = new List<NotificationResponse>();
                foreach(var notification in notifications)
                {
                    NotificationResponse notificationResponse = new NotificationResponse()
                    {
                        Id = notification.Id,
                        Message = notification.Message,
                        UserId = notification.UserId,
                        Created = notification.Created
                    };
                    result.Add(notificationResponse);
                }
                return result;
            }
            else { throw new ArgumentException("No notification within a month with this user id."); }
        }

        public void NotifyCreatePost(RabbitMessage<PostResponse> message) 
        {
            List<NotificationMembershipModel> notificationMembershipModels = _notificationMembershipRepository.GetNotificationMembershipModelsByCommunityId(message.Data.CommunityId);
            if (notificationMembershipModels == null) { throw new ArgumentException("No members found"); }
            foreach(var notificationMember in notificationMembershipModels)
            {
                NotificationModel notificationModel = new NotificationModel()
                {
                    Created = DateTime.UtcNow,
                    Message = message.Data.Content,
                    UserId = notificationMember.UserId,
                };
                var created = _notificationRepository.Create(notificationModel);
                if (!created) { throw new ArgumentException("Could not create notification"); }
            }
        }
    }
}
