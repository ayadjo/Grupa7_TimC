using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Services
{
    public class TourService
    {
        private TourRepository _tourRepository;

        public TourService()
        {
            _tourRepository = TourRepository.GetInstance();
        }

        public List<Tour> GetAll()
        {
            return _tourRepository.GetAll();
        }

        public Tour Get(int id)
        {
            return _tourRepository.Get(id);
        }

        public Tour Save(Tour tour) { 
        
            return _tourRepository.Save(tour);
        }

        public void Delete(Tour tour) {

            _tourRepository.Delete(tour);

        }

        public Tour Update(Tour tour)
        {
            return _tourRepository.Update(tour);
        }

        public int NextId() {

            return _tourRepository.NextId();

        }

        public List<Tour> GetByGuide(int id)
        {

           return _tourRepository.GetByGuide(id);
        }
    }
}
