using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialProject.Repository;
using InitialProject.Services;

namespace InitialProject.Controller
{
    public class TourReservationController
    {
        private readonly TourReservationService _tourReservationService;

        public TourReservationController()
        {
            _tourReservationService = new TourReservationService();
        }

        public List<TourReservation> GetAll()
        {
            return _tourReservationService.GetAll();
        }

        public TourReservation Get(int id)
        {
            return _tourReservationService.Get(id);
        }

        public TourReservation Create(TourReservation tourReservation)
        {
            return _tourReservationService.Create(tourReservation);
        }


        public void Delete(TourReservation tourReservation)
        {
            _tourReservationService.Delete(tourReservation);
        }

        public TourReservation Update(TourReservation tourReservation)
        {
            return _tourReservationService.Update(tourReservation);
        }


    }
}

