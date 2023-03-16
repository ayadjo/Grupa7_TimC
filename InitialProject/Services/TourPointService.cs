using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Services
{
    public class TourPointService
    {
        private TourPointRepository _tourPointRepository;

        public TourPointService()
        {
            _tourPointRepository = TourPointRepository.GetInstance();
        }

        public List<TourPoint> GetAll()
        {
            return _tourPointRepository.GetAll();
        }

        public TourPoint Get(int id)
        {
            return _tourPointRepository.Get(id);
        }

        public TourPoint Save(TourPoint tourPoint)
        {

            return _tourPointRepository.Save(tourPoint);
        }

        public void Delete(TourPoint tourPoint)
        {

            _tourPointRepository.Delete(tourPoint);

        }

        public TourPoint Update(TourPoint tourPoint)
        {
            return _tourPointRepository.Update(tourPoint);
        }

       

        public List<TourPoint> GetByTour(int id)
        {

            return _tourPointRepository.GetByTour(id);
        }
    }
}
