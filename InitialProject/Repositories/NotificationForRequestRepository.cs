using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repositories
{
    public class NotificationForRequestRepository : INotificationForRequestRepository
    {
        
        private const string FilePath = "../../../Resources/Data/notificationsForRequest.csv";   

        private readonly Serializer<NotificationForRequest> _serializer;

        private List<NotificationForRequest> _notifications;

        public NotificationForRequestRepository()  
        {
            _serializer = new Serializer<NotificationForRequest>();
            _notifications = _serializer.FromCSV(FilePath);
            
        }


        public List<NotificationForRequest> GetAll()
        {
            return _notifications;
        }

        public NotificationForRequest Get(int id)
        {
            return _notifications.Find(n => n.Id == id);

        }

       
        public void BindNotificationTourRequest()
        {
            foreach (NotificationForRequest notification in _notifications)
            {
                int tourRequestId = notification.TourRequest.Id;
                TourRequest request = Injector.Injector.CreateInstance<ITourRequestRepository>().Get(tourRequestId);
                if (request != null)
                {
                    notification.TourRequest = request;
                }
                else
                {
                    Console.WriteLine("Error in notificationTourRequest binding");
                }
            }
        }
       
        public NotificationForRequest Save(NotificationForRequest notification)
        {

            notification.Id = NextId();
            _notifications.Add(notification);
            _serializer.ToCSV(FilePath, _notifications);
            return notification;
        }
        public int NextId()
        {
            if (_notifications.Count < 1)
            {
                return 1;
            }
            return _notifications.Max(n => n.Id) + 1;
        }
        public void Delete(NotificationForRequest notification)
        {
            NotificationForRequest founded = _notifications.Find(n => n.Id == notification.Id);
            _notifications.Remove(founded);
            _serializer.ToCSV(FilePath, _notifications);
        }

        public NotificationForRequest Update(NotificationForRequest notification)
        {
            NotificationForRequest current = _notifications.Find(n => n.Id == notification.Id);
            int index = _notifications.IndexOf(current);
            _notifications.Remove(current);
            _notifications.Insert(index, notification);
            _serializer.ToCSV(FilePath, _notifications);
            return notification;
        }
    }
}
