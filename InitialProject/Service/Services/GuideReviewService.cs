using InitialProject.Domain.Models;
using InitialProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class GuideReviewService
    {
        private GuideReviewRepository _guideReviewRepository;

        public GuideReviewService()
        {
            _guideReviewRepository = GuideReviewRepository.GetInstance();
        }

        public List<GuideReview> GetAll()
        {
            return _guideReviewRepository.GetAll();
        }

        public GuideReview Get(int id)
        {
            return _guideReviewRepository.Get(id);
        }
        public GuideReview Save(GuideReview guideReview)
        {
            return _guideReviewRepository.Save(guideReview);
        }
        public GuideReview Update(GuideReview guideReview)
        {
            return _guideReviewRepository.Update(guideReview);
        }
        public void Delete(GuideReview guideReview)
        {
            _guideReviewRepository.Delete(guideReview);
        }
        public List<GuideReview> GetByReservation(GuideReview guideReview)
        {
            return _guideReviewRepository.GetByReservation(guideReview.Reservation.Id);
        }

        public List<GuideReview> GetAllGuideReviews(int guideId, int guestId)

        {

            List<GuideReview> guideReviews = new List<GuideReview>();

            foreach (GuideReview guideReview in _guideReviewRepository.GetAll())
            {
                if (guideReview.Reservation.Guest.Id == guestId && guideReview.Reservation.TourEvent.Tour.Guide.Id == guideId)
                {
                    guideReviews.Add(guideReview);
                }
            }
            return guideReviews;

        }
    }
}
