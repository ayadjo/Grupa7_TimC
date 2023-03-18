using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class AccommodationReservationRepository
    {
        private const string FilePath = "../../../Resources/Data/accommodationReservations.csv";

        private static AccommodationReservationRepository instance = null;

        private readonly Serializer<AccommodationReservation> _serializer;

        private List<AccommodationReservation> _accommodationReservations;

        private AccommodationReservationRepository()
        {
            _serializer = new Serializer<AccommodationReservation>();
            _accommodationReservations = _serializer.FromCSV(FilePath);
        }

        public static AccommodationReservationRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AccommodationReservationRepository();
            }
            return instance;
        }

        public void BindAccomodationReservationAccommodation()
        {
            foreach (AccommodationReservation accommodationReservation in _accommodationReservations)
            {
                int accommodationId = accommodationReservation.Accommodation.Id;
                Accommodation accommodation = AccommodationRepository.GetInstance().Get(accommodationId);
                if (accommodation != null)
                {
                    accommodationReservation.Accommodation = accommodation;
                }
                else
                {
                    Console.WriteLine("Error in accommodationReservationAccommodation binding");
                }
            }
        }

        public void BindAccomodationReservationGuest()
        {
            foreach (AccommodationReservation accommodationReservation in _accommodationReservations)
            {
                int guestId = accommodationReservation.Guest.Id;
                User guest = UserRepository.GetInstance().Get(guestId);
                if (guest != null)
                {
                    accommodationReservation.Guest = guest;
                }
                else
                {
                    Console.WriteLine("Error in accommodationReservationGuest binding");
                }
            }
        }

        public AccommodationReservation Save(AccommodationReservation accommodationReservation)
        {
            accommodationReservation.Id = NextId();
            //_accommodationReservations = _serializer.FromCSV(FilePath);
            _accommodationReservations.Add(accommodationReservation);
            _serializer.ToCSV(FilePath, _accommodationReservations);
            return accommodationReservation;
        }

        public List<AccommodationReservation> GetAll()
        {
            return _accommodationReservations;
        }
        public AccommodationReservation Get(int id)
        {
            return _accommodationReservations.Find(ar => ar.Id == id);
        }
        public AccommodationReservation Create(AccommodationReservation accommodationReservation)
        {
            accommodationReservation.Id = NextId();
            //_accommodationReservations = _serializer.FromCSV(FilePath);
            _accommodationReservations.Add(accommodationReservation);
            _serializer.ToCSV(FilePath, _accommodationReservations);
            return accommodationReservation;
        }
        public int NextId()
        {
            //_accommodationReservations = _serializer.FromCSV(FilePath);
            if (_accommodationReservations.Count < 1)
            {
                return 1;
            }
            return _accommodationReservations.Max(ar => ar.Id) + 1;
        }
        public void Delete(AccommodationReservation accommodationReservation)
        {
            //_accommodationReservations = _serializer.FromCSV(FilePath);
            AccommodationReservation founded = _accommodationReservations.Find(ar => ar.Id == accommodationReservation.Id);
            _accommodationReservations.Remove(founded);
            _serializer.ToCSV(FilePath, _accommodationReservations);
        }

        public AccommodationReservation Update(AccommodationReservation accommodationReservation)
        {
            //_accommodationReservations = _serializer.FromCSV(FilePath);
            AccommodationReservation current = _accommodationReservations.Find(ar => ar.Id == accommodationReservation.Id);
            int index = _accommodationReservations.IndexOf(current);
            _accommodationReservations.Remove(current);
            _accommodationReservations.Insert(index, accommodationReservation);       // keep ascending order of ids in file 
            _serializer.ToCSV(FilePath, _accommodationReservations);
            return accommodationReservation;
        }

    }
}
