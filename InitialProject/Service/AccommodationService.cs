using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
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
        public Accommodation Update(Accommodation accommodation)
        {
            return _accommodationRepository.Update(accommodation);
        }
        public void Delete(Accommodation accommodation)
        {
            _accommodationRepository.Delete(accommodation);
        }
        public List<Accommodation> GetByOwner(Accommodation accommodation)
        {
            return _accommodationRepository.GetByOwner(accommodation.Owner.Id);
        }
    }
}
