using InitialProject.Domain.Models;
using InitialProject.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
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

        public Accommodation SaveImages(Accommodation accommodation)
        {

            return _accommodationRepository.SaveImages(accommodation);
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

     
    }
}
