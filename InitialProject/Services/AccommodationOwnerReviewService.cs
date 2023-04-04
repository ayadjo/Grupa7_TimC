using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Services
{
    public class AccommodationOwnerReviewService
    {
        private AccommodationOwnerReviewRepository _accommodationOwnerReviewRepository;

        public AccommodationOwnerReviewService()
        {
            _accommodationOwnerReviewRepository = AccommodationOwnerReviewRepository.GetInstance();
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
    }
}
