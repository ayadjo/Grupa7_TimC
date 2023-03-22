using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Services
{
    public class AccommodationReservationService
    {
        private AccommodationReservationRepository _accommodationReservationRepository;

        public AccommodationReservationService()
        {
            _accommodationReservationRepository = AccommodationReservationRepository.GetInstance();
        }

        public List<AccommodationReservation> GetAll()
        {
            return _accommodationReservationRepository.GetAll();
        }

        public AccommodationReservation Get(int id)
        {
            return _accommodationReservationRepository.Get(id);
        }

        public AccommodationReservation Save(AccommodationReservation accommodationReservation)
        {

            return _accommodationReservationRepository.Save(accommodationReservation);
        }

        public void Delete(AccommodationReservation accommodationReservation)
        {

            _accommodationReservationRepository.Delete(accommodationReservation);

        }

        public AccommodationReservation Update(AccommodationReservation accommodationReservation)
        {
            return _accommodationReservationRepository.Update(accommodationReservation);
        }

        public int NextId()
        {

            return _accommodationReservationRepository.NextId();

        }

        private bool IsGuestWithoutReview(AccommodationReservation accommodationReservation)
        {
            bool retVal = accommodationReservation.Review.Id == -1 && DateTime.Now >= accommodationReservation.End
                           && DateTime.Now <= accommodationReservation.End.AddDays(5);

            return retVal;
        }

        public List<AccommodationReservation> GetAllReservationsWithoutReview()
        {
            List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();
            foreach (AccommodationReservation accommodationReservation in _accommodationReservationRepository.GetAll())
            {
                if (IsGuestWithoutReview(accommodationReservation))
                {
                    accommodationReservations.Add(accommodationReservation);
                }
            }

            return accommodationReservations;
        }

        public int FindNumberOfGuestsWithoutReview()
        {
            int number;
            List<AccommodationReservation> accommodationReservations = GetAllReservationsWithoutReview();
            return number = accommodationReservations.Count;

        }
    }
}
