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
    public class LocationController
    {
        private readonly LocationService _locationService;

        public LocationController()
        {
            _locationService = new LocationService();
        }

        public List<Location> GetAll()
        {
            return _locationService.GetAll();
        }


        public Location Get(int id)
        {
            return _locationService.Get(id);
        }

        public Location Save(Location location)
        {

            return _locationService.Save(location);
        }

        public void Delete(Location location)
        {

            _locationService.Delete(location);
        }

        public Location Update(Location location)
        {
            return _locationService.Update(location);
        }

        public int NextId()
        {

            return _locationService.NextId();

        }

        /*
        public List<Accommodation> GetByOwner(int id)
        {

            return _accommodationService.GetByOwner(id);
        }

        
        public List<Tour> TourSearch(string country, string city, string language, string numberOfPeople, string duration)
        {
            return _tourService.TourSearch(country, city, language, numberOfPeople, duration);
        }
        */
    }
}
