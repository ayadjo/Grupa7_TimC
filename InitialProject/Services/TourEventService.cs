using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InitialProject.Services
{
    public class TourEventService
    {

        private TourEventRepository _tourEventRepository;
        private TourReservationRepository _tourReservationRepository;

        public TourEventService()
        {
            _tourEventRepository = TourEventRepository.GetInstance();
            _tourReservationRepository = TourReservationRepository.GetInstance();
        }

        public List<TourEvent> GetAll()
        {
            return _tourEventRepository.GetAll();
        }

        public TourEvent Get(int id)
        {
            return _tourEventRepository.Get(id);
        }

        public TourEvent Save(TourEvent tourEvent)
        {

            return _tourEventRepository.Save(tourEvent);
        }

        public void Delete(TourEvent tourEvent)
        {

            _tourEventRepository.Delete(tourEvent);

        }

        public TourEvent Update(TourEvent tourEvent)
        {
            return _tourEventRepository.Update(tourEvent);
        }


        public List<TourEvent> GetByTour(int id)
        {

            return _tourEventRepository.GetByTour(id);
        }

        public int CheckAvailability(TourEvent tourEvent)
        {
            int numOfPeople = 0;
            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.TourEvent.Id == tourEvent.Id)
                {
                    numOfPeople += tourReservation.NumberOfPeople;   
                }
            }
            return numOfPeople;
        }

        public List<TourReservation> GetAllTourReservationForTourEvent(TourEvent tourEvent)
        {
            List<TourReservation> tourReservationList = new List<TourReservation>();
            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.TourEvent.Id == tourEvent.Id)
                {
                    tourReservationList.Add(tourReservation);
                }
            }
            return tourReservationList;
        }

        public List<TourEvent> GetAvailableTourEventsForLocation(Location location, int numberOfPeople)
        {
            List<TourEvent> tourEvents = new List<TourEvent>();


            foreach (TourEvent tourEvent in _tourEventRepository.GetAll())
            {
                int freePlaces = tourEvent.Tour.MaxGuests - CheckAvailability(tourEvent);
                if (tourEvent.StartTime > DateTime.Now && tourEvent.Tour.Location.City == location.City && tourEvent.Tour.Location.Country == location.Country && freePlaces > numberOfPeople)
                {
                    tourEvents.Add(tourEvent);
                }
            }
            return tourEvents;
        }

        
        
        public List<TourEvent> GetTourEventsForNow()
        {
            List<TourEvent> _tourEventsForNow = new List<TourEvent>();

            foreach (TourEvent tourEvent in _tourEventRepository.GetAll()) {

                if (tourEvent.StartTime.Date == DateTime.Today) {
                    _tourEventsForNow.Add(tourEvent);
                }
            }
            return _tourEventsForNow ;
        }
    }
}
