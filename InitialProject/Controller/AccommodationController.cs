using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InitialProject.Controller
{
    public class AccommodationController
    {
        private readonly AccommodationRepository _accommodations;

        public AccommodationController()
        {
            _accommodations = new AccommodationRepository();
        }

        public List<Accommodation> GetAll()
        {
            return _accommodations.GetAll();
        }

        public Accommodation Get(Accommodation accommodation)
        {
            return _accommodations.Get(accommodation.Id);
        }
        public Accommodation Create(Accommodation accommodation)
        {
            return _accommodations.Create(accommodation);
        }
        public void Delete(Accommodation accommodation)
        {
            _accommodations.Delete(accommodation);
        }
        public void Update(Accommodation accommodation)
        {
            _accommodations.Update(accommodation);
        }
    }
}
