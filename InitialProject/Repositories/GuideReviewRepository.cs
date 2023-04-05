using InitialProject.Domain.Models;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repositories
{
    public class GuideReviewRepository
    {
        private const string FilePath = "../../../Resources/Data/guideReviews.csv";

        private static GuideReviewRepository instance = null;

        private readonly Serializer<GuideReview> _serializer;
        
        private List<GuideReview> _guideReviews;

        private GuideReviewRepository()
        {
            _serializer = new Serializer<GuideReview>();
            _guideReviews = _serializer.FromCSV(FilePath);
        }
        public static GuideReviewRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new GuideReviewRepository();
            }
            return instance;
        }
       
        public List<GuideReview> GetAll()
        {
            return _guideReviews;
        }
        public GuideReview Get(int id)
        {
            return _guideReviews.Find(gR => gR.Id == id);
        }
        public GuideReview Save(GuideReview guestReview)
        {
            guestReview.Id = NextId();
            _guideReviews.Add(guestReview);
            _serializer.ToCSV(FilePath, _guideReviews);
            return guestReview;
        }
        public int NextId()
        {
            if (_guideReviews.Count < 1)
            {
                return 1;
            }
            return _guideReviews.Max(gR => gR.Id) + 1;
        }
        public void Delete(GuideReview guideReview)
        {
            GuideReview founded = _guideReviews.Find(gR => gR.Id == guideReview.Id);
            _guideReviews.Remove(founded);
            _serializer.ToCSV(FilePath, _guideReviews);
        }

        public GuideReview Update(GuideReview guideReview)
        {
            GuideReview current = _guideReviews.Find(a => a.Id == guideReview.Id);
            int index = _guideReviews.IndexOf(current);
            _guideReviews.Remove(current);
            _guideReviews.Insert(index, guideReview);       
            _serializer.ToCSV(FilePath, _guideReviews);
            return guideReview;
        }

        public List<GuideReview> GetByReservation(int reservationId)
        {
            return _guideReviews.FindAll(gR => gR.Reservation.Id == reservationId);
        }
    }
}
