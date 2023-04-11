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
            ReservationRescheduleRequestRepository reservationRescheduleRequestRepository = new ReservationRescheduleRequestRepository();
            reservationRescheduleRequestRepository.BindReservationRescheduleRequestWithAccommodationReservation();
            reservationRescheduleRequestRepository.BindReservationRescheduleRequestWithUser();

            _implementations.Add(typeof(IReservationRescheduleRequestRepository), reservationRescheduleRequestRepository);
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

