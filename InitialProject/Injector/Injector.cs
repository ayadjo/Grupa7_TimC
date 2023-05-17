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
            voucherRepository.BindVoucherUser();
            
            AccommodationOwnerReviewRepository accommodationOwnerReviewRepository = new AccommodationOwnerReviewRepository();
            accommodationOwnerReviewRepository.BindAccommodationOwnerReviewWithAccommodationReservation();

            ReservationRescheduleRequestRepository reservationRescheduleRequestRepository = new ReservationRescheduleRequestRepository();
            reservationRescheduleRequestRepository.BindReservationRescheduleRequestWithAccommodationReservation();
            reservationRescheduleRequestRepository.BindReservationRescheduleRequestWithUser();

            NotificationRepository notificationRepository = new NotificationRepository();
            notificationRepository.BindNotificationTourReservation();


            TourRequestRepository tourRequestRepository = new TourRequestRepository();
            tourRequestRepository.BindTourRequestUser();
            tourRequestRepository.BindTourRequestLocation();

            AccommodationRenovationRepository accommodationRenovationRepository = new AccommodationRenovationRepository();
            accommodationRenovationRepository.BindAccommodationRenovationWithAccommodation();
            /*NotificationForRequestRepository notificationForRequestRepository = new NotificationForRequestRepository();
            notificationForRequestRepository.BindNotificationTourRequest();*/


            RenovationRecommendationRepository renovationRecommendationRepository = new RenovationRecommendationRepository();
            _implementations.Add(typeof(IVoucherRepository), voucherRepository);
            _implementations.Add(typeof(IAccommodationOwnerReviewRepository), accommodationOwnerReviewRepository);
            _implementations.Add(typeof(IReservationRescheduleRequestRepository), reservationRescheduleRequestRepository);
            _implementations.Add(typeof(INotificationRepository), notificationRepository);
            _implementations.Add(typeof(ITourRequestRepository), tourRequestRepository);
            _implementations.Add(typeof(IAccommodationRenovationRepository), accommodationRenovationRepository);
            _implementations.Add(typeof(IRenovationRecommendationRepository), renovationRecommendationRepository);
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
