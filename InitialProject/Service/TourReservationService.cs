using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    internal class TourReservationService
    {
        private TourReservationRepository _tourReservationRepository;

        public TourReservationService()
        {
            _tourReservationRepository = TourReservationRepository.GetInstance();
        }

        public List<TourReservation> GetAll()
        {
            return _tourReservationRepository.GetAll();
        }

        public TourReservation Get(int id)
        {
            return _tourReservationRepository.Get(id);
        }

        public TourReservation Create(TourReservation tourReservation)
        {
            return _tourReservationRepository.Create(tourReservation);
        }


        public void Delete(TourReservation tourReservation)
        {
            _tourReservationRepository.Delete(tourReservation);
        }

        public TourReservation Update(TourReservation tourReservation)
        {
            return _tourReservationRepository.Update(tourReservation);
        }

        public List<User> AllGuestsThatDidntComeYet(TourEvent tourEvent)
        {
            List<User> users = new List<User>();

            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.TourPointWhenGuestCame.Id == -1 && tourReservation.TourEvent.Id == tourEvent.Id )
                {
                    users.Add(tourReservation.Guest);
                    
                }

            }

            return users;
        }

        public TourReservation FindTourReservationForUserAndTourEvent(User user, TourEvent tourEvent)
        {
            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.Guest.Id == user.Id && tourReservation.TourEvent.Id == tourEvent.Id)
                {
                    return tourReservation;

                }
            }
            return null;
        }

    }
}
