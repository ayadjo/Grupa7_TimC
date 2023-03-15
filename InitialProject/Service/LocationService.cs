using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class LocationService
    {
        private LocationRepository _locationRepository;

        public LocationService()
        {
            _locationRepository = LocationRepository.GetInstance();
        }

        public List<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }

        public Location Get(int id)
        {
            return _locationRepository.Get(id);
        }
        public Location Save(Location location)
        {
            return _locationRepository.Save(location);
        }
        public Location Update(Location location)
        {
            return _locationRepository.Update(location);
        }
        public void Delete(Location location)
        {
            _locationRepository.Delete(location);
        }
        
    }
}
