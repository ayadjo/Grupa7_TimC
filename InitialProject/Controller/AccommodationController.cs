using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    public class AccommodationController
    {
        private readonly AccommodationService _accommodationService;

        public AccommodationController()
        {
            _accommodationService = new AccommodationService();
        }

        public List<Accommodation> GetAll()
        {
            return _accommodationService.GetAll();
        }


        public Accommodation Get(int id)
        {
            return _accommodationService.Get(id);
        }

        public Accommodation Save(Accommodation accommodation)
        {

            return _accommodationService.Save(accommodation);
        }

        public Accommodation SaveCascadeImages(Accommodation accommodation)
        {
            return _accommodationService.SaveCascadeImages(accommodation);
        }

        public void Delete(Accommodation accommodation)
        {

            _accommodationService.Delete(accommodation);

        }

        public Accommodation Update(Accommodation accommodation)
        {
            return _accommodationService.Update(accommodation);
        }

        public int NextId()
        {

            return _accommodationService.NextId();

        }

        public List<Accommodation> GetByOwner(int id)
        {

            return _accommodationService.GetByOwner(id);
        }

        /*
        public List<Accommodation> AccommodationSearch(string name, string country, string city, string type, string maxGuests, string minDaysForReservation)
        {
            return _accommodationService.AccommodationSearch(name, country, city, type, maxGuests, minDaysForReservation);
        }
        */
    }
}
