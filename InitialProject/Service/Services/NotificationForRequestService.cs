using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class NotificationForRequestService
    {
        private INotificationForRequestRepository _notificationRepository;

        public NotificationForRequestService()
        {
            _notificationRepository = Injector.Injector.CreateInstance<INotificationForRequestRepository>();
        }

        public List<NotificationForRequest> GetAll()
        {
            return _notificationRepository.GetAll();
        }

        public NotificationForRequest Get(int id)
        {
            return _notificationRepository.Get(id);
        }

        public NotificationForRequest Save(NotificationForRequest notification)
        {
            return _notificationRepository.Save(notification);
        }

        public void Delete(NotificationForRequest notification)
        {
            _notificationRepository.Delete(notification);
        }

        public void Update(NotificationForRequest notification)
        {
            _notificationRepository.Update(notification);
        }

        public int NextId()
        {
            return _notificationRepository.NextId();
        }
    }
}
