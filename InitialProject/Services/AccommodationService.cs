using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Services
{
    public class AccommodationService
    {
        private AccommodationRepository _accommodationRepository;

        public AccommodationService()
        {
            _accommodationRepository = AccommodationRepository.GetInstance();
        }

        public List<Accommodation> GetAll()
        {
            return _accommodationRepository.GetAll();
        }

        public Accommodation Get(int id)
        {
            return _accommodationRepository.Get(id);
        }

        public Accommodation Save(Accommodation accommodation)
        {

            return _accommodationRepository.Save(accommodation);
        }

        public void Delete(Accommodation accommodation)
        {

            _accommodationRepository.Delete(accommodation);

        }

        public Accommodation Update(Accommodation accommodation)
        {
            return _accommodationRepository.Update(accommodation);
        }

        public int NextId()
        {

            return _accommodationRepository.NextId();

        }

        public List<Accommodation> GetByOwner(int id)
        {

            return _accommodationRepository.GetByOwner(id);
        }

        /*
        private bool SearchCondition(Accommodation accommodation, string name, string country, string city, string type, string maxGuests, string minDaysForReservation)
        {
            bool retVal = accommodation.Location.Country.Contains(country) && accommodation.Location.City.Contains(city) && accommodation.Type.ToString().Contains(type);

            if (maxGuests != null && maxGuests != "")
            {
                int maxGuestsNum = Convert.ToInt32(maxGuests);
                retVal = retVal && accommodation.MaxGuests > maxGuestsNum;
            }

            if (minDaysForReservation != null && minDaysForReservation != "")
            {
                int minDaysForReservationNum = Convert.ToInt32(minDaysForReservation);
                retVal = retVal && accommodation.MinDaysForReservation > minDaysForReservationNum;
            }
            return retVal;

        }

        public List<Accommodation> AccommodationSearch(string name, string country, string city, string type, string maxGuests, string minDaysForReservation)
        {
            try
            {
                List<Accommodation> accommodations = AccommodationSearchLogic(name, country, city, type, maxGuests, minDaysForReservation);
                return accommodations;
            }
            catch (Exception e)
            {
                return new List<Accommodation>();
            }
        }

        private List<Accommodation> AccommodationSearchLogic(string name, string country, string city, string type, string maxGuests, string minDaysForReservation)
        {
            List<Accommodation> accommodations = new List<Accommodation>();

            foreach (Accommodation accommodation in _accommodationRepository.GetAll())
            {
                if (SearchCondition(accommodation, name, country, city, type, maxGuests, minDaysForReservation))
                {
                    accommodations.Add(accommodation);
                }
            }
            return accommodations;
        }

        public IEnumerable<Accommodation> AccommodationSearchLINQ(string name, string country, string city, string type, string maxGuests, string minDaysForReservation)
        {

            return _accommodationRepository.GetAll().Where(a => SearchCondition(a, name, country, city, type, maxGuests, minDaysForReservation));
        }
        */
    }
}
