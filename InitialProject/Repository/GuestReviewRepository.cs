using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class GuestReviewRepository
    {
        private const string FilePath = "../../../Resources/Data/guestReviews.csv";

        private static GuestReviewRepository instance = null;

        private readonly Serializer<GuestReview> _serializer;

        private List<GuestReview> _guestReviews;

        private GuestReviewRepository()
        {
            _serializer = new Serializer<GuestReview>();
            _guestReviews = _serializer.FromCSV(FilePath);
        }
        public static GuestReviewRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new GuestReviewRepository();
            }
            return instance;
        }
        public void BindGuestReviewWithAccommodationReservation()
        {
            foreach (GuestReview guestReview in _guestReviews)
            {
                int accommodationReservationId = guestReview.Reservation.Id;
                AccommodationReservation reservation = AccommodationReservationRepository.GetInstance().Get(accommodationReservationId);
                if (reservation != null)
                {
                    guestReview.Reservation = reservation;
                }
                else
                {
                    Console.WriteLine("Error in guestReviewAccommodationReservation binding");
                }
            }
        }
        public List<GuestReview> GetAll()
        {
            return _guestReviews;
        }
        public GuestReview Get(int id)
        {
            return _guestReviews.Find(gR => gR.Id == id);
        }
        public GuestReview Save(GuestReview guestReview)
        {
            guestReview.Id = NextId();
            //_guestReviews = _serializer.FromCSV(FilePath);
            _guestReviews.Add(guestReview);
            _serializer.ToCSV(FilePath, _guestReviews);
            return guestReview;
        }
        public int NextId()
        {
            //_guestReviews = _serializer.FromCSV(FilePath);
            if (_guestReviews.Count < 1)
            {
                return 1;
            }
            return _guestReviews.Max(gR => gR.Id) + 1;
        }
        public void Delete(GuestReview guestReview)
        {
            //_guestReviews = _serializer.FromCSV(FilePath);
            GuestReview founded = _guestReviews.Find(gR => gR.Id == guestReview.Id);
            _guestReviews.Remove(founded);
            _serializer.ToCSV(FilePath, _guestReviews);
        }

        public GuestReview Update(GuestReview guestReview)
        {
            //_guestReviews = _serializer.FromCSV(FilePath);
            GuestReview current = _guestReviews.Find(a => a.Id == guestReview.Id);
            int index = _guestReviews.IndexOf(current);
            _guestReviews.Remove(current);
            _guestReviews.Insert(index, guestReview);       // keep ascending order of ids in file 
            _serializer.ToCSV(FilePath, _guestReviews);
            return guestReview;
        }

        public List<GuestReview> GetByReservation(int reservationId)
        {
            //_guestReviews = _serializer.FromCSV(FilePath);
            return _guestReviews.FindAll(gR => gR.Reservation.Id == reservationId);
        }
    }
}
