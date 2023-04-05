using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialProject.Repositories;
using InitialProject.Service.Services;

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

        public TourReservation Save(TourReservation tourReservation)
        {
            return _tourReservationService.Save(tourReservation);
        }


        public void Delete(TourReservation tourReservation)
        {
            _tourReservationService.Delete(tourReservation);
        }

        public TourReservation Update(TourReservation tourReservation)
        {
            return _tourReservationService.Update(tourReservation);
        }

        public List<User> FindGuestsThatDidntComeYet(TourEvent tourEvent) {

            return _tourReservationService.FindGuestsThatDidntComeYet(tourEvent);
        }

        public TourReservation FindTourReservationForUserAndTourEvent(User user, TourEvent tourEvent)
        {
            return _tourReservationService.FindTourReservationForUserAndTourEvent(user, tourEvent);
        }

    }
}

