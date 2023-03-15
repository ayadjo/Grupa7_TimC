using InitialProject.Model;
using InitialProject.Observser;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    public class LocationController
    {
        private readonly LocationRepository _locations;

        public LocationController()
        {
            _locations = new LocationRepository();
        }

        public List<Location> GetLocations()
        {
            return _locations.GetAll();
        }

        public void Subscribe(IObserver observer)
        {
            _locations.Subscribe(observer);
        }
    }
}
