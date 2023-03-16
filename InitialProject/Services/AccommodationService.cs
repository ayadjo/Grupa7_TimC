using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
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
    }
}
