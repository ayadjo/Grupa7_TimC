using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Services
{
    public class GuestReviewService
    {
        private GuestReviewRepository _guestReviewRepository;

        public GuestReviewService()
        {
            _guestReviewRepository = GuestReviewRepository.GetInstance();
        }

        public List<GuestReview> GetAll()
        {
            return _guestReviewRepository.GetAll();
        }

        public GuestReview Get(int id)
        {
            return _guestReviewRepository.Get(id);
        }
        public GuestReview Save(GuestReview guestReview)
        {
            return _guestReviewRepository.Save(guestReview);
        }
        public GuestReview Update(GuestReview guestReview)
        {
            return _guestReviewRepository.Update(guestReview);
        }
        public void Delete(GuestReview guestReview)
        {
            _guestReviewRepository.Delete(guestReview);
        }
        public List<GuestReview> GetByReservation(GuestReview guestReview)
        {
            return _guestReviewRepository.GetByReservation(guestReview.Reservation.Id);
        }
    }
}
