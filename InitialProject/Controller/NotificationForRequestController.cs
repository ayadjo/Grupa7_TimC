using InitialProject.Domain.Models;
using InitialProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    public class NotificationForRequestController
    {
        private readonly NotificationForRequestService _notificationService;

        public NotificationForRequestController()
        {
            _notificationService = new NotificationForRequestService();
        }

        public List<NotificationForRequest> GetAll()
        {
            return _notificationService.GetAll();
        }

        public NotificationForRequest Get(int id)
        {
            return _notificationService.Get(id);
        }

        public NotificationForRequest Save(NotificationForRequest notification)
        {

            return _notificationService.Save(notification);
        }

        public void Delete(NotificationForRequest notification)
        {
            _notificationService.Delete(notification);
        }


        public void Update(NotificationForRequest notification)
        {
            _notificationService.Update(notification);
        }

        public int NextId()
        {
            return _notificationService.NextId();
        }

        public List<NotificationForRequest> GetNotificationForUser(int userId)
        {
            return _notificationService.GetNotificationForUser(userId);
        }
    }
}
