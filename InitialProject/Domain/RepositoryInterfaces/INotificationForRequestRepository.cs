using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface INotificationForRequestRepository
    {
        List<NotificationForRequest> GetAll();

        NotificationForRequest Get(int id);

        public NotificationForRequest Save(NotificationForRequest notification);

        void Delete(NotificationForRequest notification);

        NotificationForRequest Update(NotificationForRequest notification);

        public int NextId();

    }
}
