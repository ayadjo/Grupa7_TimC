using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
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
        public void Update(Accommodation accommodation)
        {
            _accommodationService.Update(accommodation);
        }

        public void GetByOwner(Accommodation accommodation)
        {
            _accommodationService.GetByOwner(accommodation);
        }

    }
}
