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

        public TourEventService()
        {
            _tourEventRepository = TourEventRepository.GetInstance();
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
