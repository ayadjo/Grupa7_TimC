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
    public class TourController
    {
        private readonly TourService _tourService;

        public TourController()
        {
            _tourService = new TourService();
        }

        public List<Tour> GetAll()
        {
            return _tourService.GetAll();
        }


        public Tour Get(int id)
        {
            return _tourService.Get(id);
        }

        public Tour Save(Tour tour)
        {

            return _tourService.Save(tour);
        }

        public void Delete(Tour tour)
        {

            _tourService.Delete(tour);

        }

        public Tour Update(Tour tour)
        {
            return _tourService.Update(tour);
        }

        public int NextId()
        {

            return _tourService.NextId();

        }

        public List<Tour> GetByGuide(int id)
        {

            return _tourService.GetByGuide(id);
        }

        public Tour SaveCascadeImages(Tour tour)
        {
            return _tourService.SaveCascadeImages(tour);
        }

        public Tour SaveCascadeTourPoints(Tour tour)
        {
            return _tourService.SaveCascadeTourPoints(tour);
        }

        public Tour SaveCascadeImagesTourPoints(Tour tour)
        {

            return _tourService.SaveCascadeImagesTourPoints(tour);
        }
    }
}
