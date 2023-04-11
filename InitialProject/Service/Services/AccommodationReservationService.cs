using InitialProject.Domain.Models;
using InitialProject.Repositories;
using InitialProject.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
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
            bool retVal = accommodationReservation.GuestReview.Id == -1 && DateTime.Now >= accommodationReservation.End
                           && DateTime.Now <= accommodationReservation.End.AddDays(5);

            return retVal;
        }

        public List<AccommodationReservation> GetAllReservationsWithoutGuestReview()
        {
            List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();
            foreach (AccommodationReservation accommodationReservation in _accommodationReservationRepository.GetAll())
            {
                if (IsGuestWithoutReview(accommodationReservation) && accommodationReservation.Accommodation.Owner.Id == SignInForm.LoggedUser.Id)
                {
                    accommodationReservations.Add(accommodationReservation);
                }
            }

            return accommodationReservations;
        }

        public int FindNumberOfGuestsWithoutReview()
        {
            int number;
            List<AccommodationReservation> accommodationReservations = GetAllReservationsWithoutGuestReview();
            return number = accommodationReservations.Count;

        }

        public List<AccommodationReservation> GetByUserId(int guest)
        {
            List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();
            foreach (AccommodationReservation accommodationReservation in _accommodationReservationRepository.GetAll())
            {
                if (accommodationReservation.Guest.Id == guest)
                {
                    accommodationReservations.Add(accommodationReservation);
                }
            }

            return accommodationReservations;
        }

        public List<AccommodationReservation> GetAllReservationsWithoutAccommodationOwnerReview(int guest)
        {
            List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();
            foreach (AccommodationReservation accommodationReservation in _accommodationReservationRepository.GetAll())
            {
                if (accommodationReservation.Guest.Id == guest)
                {
                    if (IsAccommodationWithoutReview(accommodationReservation))
                    {
                        accommodationReservations.Add(accommodationReservation);
                    }
                }
            }
            return accommodationReservations;
        }

        private bool IsAccommodationWithoutReview(AccommodationReservation accommodationReservation)
        {
            bool retVal = accommodationReservation.AccommodationReview.Id == -1 /*&& DateTime.Now >= accommodationReservation.End
                           && DateTime.Now <= accommodationReservation.End.AddDays(5)*/;

            return retVal;
        }

        public bool IsDatesIntertwine(DateTime StartFirst, DateTime EndFirst, DateTime StartSecond, DateTime EndSecond)
        {
            return (StartSecond.Date <= EndFirst.Date && EndSecond.Date >= StartFirst.Date);
        }

        public bool IsReschedulePossible(ReservationRescheduleRequest reservationRescheduleRequest)
        {
            List<AccommodationReservation> reservations = _accommodationReservationRepository.GetByAccommodationId(reservationRescheduleRequest.Reservation.Accommodation.Id);
            foreach (AccommodationReservation reservation in reservations)
            {
                if (reservation.Id == reservationRescheduleRequest.Reservation.Id)
                {
                    reservations.Remove(reservation);
                    break;
                }
            }
            foreach (AccommodationReservation reservation in reservations)
            {
                if (IsDatesIntertwine(reservation.Start, reservation.End, reservationRescheduleRequest.NewStart, reservationRescheduleRequest.NewEnd))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
