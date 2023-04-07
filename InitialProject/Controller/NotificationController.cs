using InitialProject.Domain.Models;
using InitialProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    public class NotificationController
    {
        private readonly NotificationService _notificationService;

        public NotificationController()
        {
            _notificationService = new NotificationService();
        }

        public Notification Save(Notification notification)
        {

            return _notificationService.Save(notification);
        }

        public void Delete(Notification notification)
        {
            _notificationService.Delete(notification);
        }

        public List<Notification> GetNotificationForUser(int userId)
        {
            return _notificationService.GetNotificationForUser(userId);
        }

    }
}
