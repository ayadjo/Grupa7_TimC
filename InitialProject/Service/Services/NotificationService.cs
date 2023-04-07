using InitialProject.Domain.Models;
using InitialProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class NotificationService
    {
        private NotificationRepository _notificationRepository;

        public NotificationService()
        {
            _notificationRepository = NotificationRepository.GetInstance();
        }

        public List<Notification> GetAll()
        {
            return _notificationRepository.GetAll();
        }


        public Notification Save(Notification notification)
        {
            return _notificationRepository.Save(notification);
        }
       
        public void Delete(Notification notification)
        {
            _notificationRepository.Delete(notification);
        }

        public void Update(Notification notification)
        {
            _notificationRepository.Update(notification);
        }

        public List<Notification> GetNotificationForUser(int userId)
        {
            
            List<Notification> notificationList = new List<Notification>();
            foreach (Notification notification in _notificationRepository.GetAll())
            {
                if (notification.TourReservation.Guest.Id == userId)
                {
                    notification.IsDelivered = true;
                    _notificationRepository.Update(notification);
                    notificationList.Add(notification);
                }
            }
            return notificationList;
           
        }

    }
}
