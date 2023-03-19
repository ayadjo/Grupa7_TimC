using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    public class TourPointController
    {

        private readonly TourPointService _tourPointService;

        public TourPointController()
        {
            _tourPointService = new TourPointService();
        }

        public List<TourPoint> GetAll()
        {
            return _tourPointService.GetAll();
        }

        public TourPoint Get(int id)
        {
            return _tourPointService.Get(id);
        }

        public TourPoint Save(TourPoint tourPoint)
        {

            return _tourPointService.Save(tourPoint);
        }

        public void Delete(TourPoint tourPoint)
        {

            _tourPointService.Delete(tourPoint);

        }

        public TourPoint Update(TourPoint tourPoint)
        {
            return _tourPointService.Update(tourPoint);
        }

        public List<TourPoint> GetByTour(int id)
        {

            return _tourPointService.GetByTour(id);
        }

    }
}
