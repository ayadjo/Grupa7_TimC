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
    public class AccommodationController
    {
        private readonly AccommodationRepository _accommodations;

        public AccommodationController()
        {
            _accommodations = new AccommodationRepository();
        }

        public List<Accommodation> GetAccommodations()
        {
            return _accommodations.GetAll();
        }

        public void Subscribe(IObserver observer)
        {
            _accommodations.Subscribe(observer);
        }
    }
}
