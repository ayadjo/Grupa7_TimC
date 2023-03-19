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
    public class TourEventController
    {

        private readonly TourEventService _tourEventService;

        public TourEventController()
        {
            _tourEventService = new TourEventService();
        }

        public List<TourEvent> GetAll()
        {
            return _tourEventService.GetAll();
        }

        public TourEvent Get(int id)
        {
            return _tourEventService.Get(id);
        }

        public TourEvent Save(TourEvent tourEvent)
        {

            return _tourEventService.Save(tourEvent);
        }

        public void Delete(TourEvent tourEvent)
        {

            _tourEventService.Delete(tourEvent);

        }

        public TourEvent Update(TourEvent tourEvent)
        {
            return _tourEventService.Update(tourEvent);
        }

        
        public List<TourEvent> GetByGuide(int id)
        {

            return _tourEventService.GetByTour(id);
        }

        public int CheckAvailability(TourEvent tourEvent)
        {
            return _tourEventService.CheckAvailability(tourEvent);
        }

        public List<TourReservation> GetAllTourReservationForTourEvent(TourEvent tourEvent)
        {
            return _tourEventService.GetAllTourReservationForTourEvent(tourEvent);
        }

        public List<TourEvent> GetTourEventsForLocation(Location location)
        {
            return _tourEventService.GetTourEventsForLocation(location);
        }

        public List<TourEvent> GetAllTourEventsForTour(Tour tour)
        {
            return _tourEventService.GetAllTourEventsForTour(tour);
        }
        public List<TourEvent> GetTourEventsForNow()
        {
            return _tourEventService.GetTourEventsForNow(); 
        }

    }
}
