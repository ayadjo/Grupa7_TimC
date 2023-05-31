using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Injector
{

    public class Injector
    {
        private static Dictionary<Type, object> _implementations = new Dictionary<Type, object>
        {
        };

        public static void BindComponents()
        {

            VoucherRepository voucherRepository = new VoucherRepository();
            
            AccommodationOwnerReviewRepository accommodationOwnerReviewRepository = new AccommodationOwnerReviewRepository();

            ReservationRescheduleRequestRepository reservationRescheduleRequestRepository = new ReservationRescheduleRequestRepository();
            NotificationRepository notificationRepository = new NotificationRepository();


            TourRequestRepository tourRequestRepository = new TourRequestRepository();
            TourRequestAcceptedNotificationRepository tourRequestAcceptedNotificationRepository = new TourRequestAcceptedNotificationRepository();
            /*NotificationForRequestRepository notificationForRequestRepository = new NotificationForRequestRepository();
            notificationForRequestRepository.BindNotificationTourRequest();*/


            _implementations.Add(typeof(IVoucherRepository), voucherRepository);
            _implementations.Add(typeof(IAccommodationOwnerReviewRepository), accommodationOwnerReviewRepository);
            _implementations.Add(typeof(IReservationRescheduleRequestRepository), reservationRescheduleRequestRepository);
            _implementations.Add(typeof(INotificationRepository), notificationRepository);
            _implementations.Add(typeof(ITourRequestRepository), tourRequestRepository);
            _implementations.Add(typeof(ITourRequestAcceptedNotificationRepository), tourRequestAcceptedNotificationRepository);

            accommodationOwnerReviewRepository.BindAccommodationOwnerReviewWithAccommodationReservation();
            reservationRescheduleRequestRepository.BindReservationRescheduleRequestWithAccommodationReservation();
            reservationRescheduleRequestRepository.BindReservationRescheduleRequestWithUser();

            notificationRepository.BindNotificationTourReservation();
            tourRequestRepository.BindTourRequestUser();
            tourRequestRepository.BindTourRequestLocation();
            voucherRepository.BindVoucherUser();
            tourRequestAcceptedNotificationRepository.BindTourRequestAcceptedNotificationTourRequest();
             

            RenovationRecommendationRepository renovationRecommendationRepository = new RenovationRecommendationRepository();
            //_implementations.Add(typeof(INotificationForRequestRepository), notificationForRequestRepository);
        }

        public static T CreateInstance<T>()
        {
            Type type = typeof(T);

            if (_implementations.ContainsKey(type))
            {
                return (T)_implementations[type];
            }

            throw new ArgumentException($"No implementation found for type {type}");
        }
    }
}
