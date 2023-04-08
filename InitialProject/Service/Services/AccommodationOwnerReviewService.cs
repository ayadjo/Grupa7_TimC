using InitialProject.Domain.Models;
using InitialProject.Repositories;
using InitialProject.WPF.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class AccommodationOwnerReviewService
    {
        private AccommodationOwnerReviewRepository _accommodationOwnerReviewRepository;

        private AccommodationReservationRepository _accommodationReservationRepository;

        public AccommodationOwnerReviewService()
        {
            _accommodationOwnerReviewRepository = AccommodationOwnerReviewRepository.GetInstance();
            _accommodationReservationRepository = AccommodationReservationRepository.GetInstance();
        }

        public List<AccommodationOwnerReview> GetAll()
        {
            return _accommodationOwnerReviewRepository.GetAll();
        }

        public AccommodationOwnerReview Get(int id)
        {
            return _accommodationOwnerReviewRepository.Get(id);
        }
        public AccommodationOwnerReview Save(AccommodationOwnerReview accommodationOwnerReview)
        {
            return _accommodationOwnerReviewRepository.Save(accommodationOwnerReview);
        }
        public AccommodationOwnerReview Update(AccommodationOwnerReview accommodationOwnerReview)
        {
            return _accommodationOwnerReviewRepository.Update(accommodationOwnerReview);
        }
        public void Delete(AccommodationOwnerReview accommodationOwnerReview)
        {
            _accommodationOwnerReviewRepository.Delete(accommodationOwnerReview);
        }
        public List<AccommodationOwnerReview> GetByReservation(AccommodationOwnerReview accommodationOwnerReview)
        {
            return _accommodationOwnerReviewRepository.GetByReservation(accommodationOwnerReview.Reservation.Id);
        }

        private bool isValidReview(AccommodationReservation reservation)
        {
            return reservation.GuestReview.Id != -1 && reservation.AccommodationReview.Id != -1 && reservation.Accommodation.Owner.Id == SignInForm.LoggedUser.Id;
        }

        public List<AccommodationOwnerReview> GetAllValidReviews(Accommodation accommodation)
        {
            List<AccommodationOwnerReview> reviews = new List<AccommodationOwnerReview>();
            foreach (AccommodationReservation reservation in _accommodationReservationRepository.GetAll())
            {
                if (isValidReview(reservation) && reservation.Accommodation.Id == accommodation.Id)
                {
                    reviews.Add(reservation.AccommodationReview);
                }
            }

            return reviews;
        }

        public int GetReviewsCountForOwner(int ownerId)
        {
            int count = 0;
            foreach (AccommodationOwnerReview ownerReview in _accommodationOwnerReviewRepository.GetAll())
            {
                if (ownerReview.Reservation.Accommodation.Owner.Id == ownerId)
                {
                    count++;
                }
            }
            return count;
        }

        public double GetReviewsAverageForOwner(int ownerId)
        {
            int count = 0;
            double averageReview = 0;
            foreach (AccommodationOwnerReview ownerReview in _accommodationOwnerReviewRepository.GetAll())
            {
                if (ownerReview.Reservation.Accommodation.Owner.Id == ownerId)
                {
                    count++;
                    averageReview += (ownerReview.Cleanliness + ownerReview.Correctness) / 2;

                }
            }
            return averageReview / count;
        }

        //napraviti is super Owner
    }
}
