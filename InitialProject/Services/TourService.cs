using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Serializer;
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

        private bool IsConditionValid(Tour tour, string country, string city, string language, string numberOfPeople, string duration)
        {
            bool retVal = tour.Location.Country.Contains(country, StringComparison.OrdinalIgnoreCase) && tour.Location.City.Contains(city, StringComparison.OrdinalIgnoreCase) && tour.Languages.Contains(language, StringComparison.OrdinalIgnoreCase);

            if (numberOfPeople != null && numberOfPeople != "")
            {
                int numberOfPeopleNum = Convert.ToInt32(numberOfPeople);
                retVal = retVal && tour.MaxGuests >= numberOfPeopleNum;
            }

            if (duration != null && duration != "")
            {
                int durationNum = Convert.ToInt32(duration);
                retVal = retVal && tour.Duration >= durationNum;
            }
            return retVal;

        }

        public List<Tour> SearchTours(string country, string city, string language, string numberOfPeople, string duration)
        {
            try
            {
                List<Tour> tours = SearchToursLogic(country, city, language, numberOfPeople, duration);
                return tours;
            }
            catch (Exception e)
            {
                return new List<Tour>();
            }
        }

        private List<Tour> SearchToursLogic(string country, string city, string language, string numberOfPeople, string duration)
        {
            List<Tour> tours = new List<Tour>();

            foreach(Tour tour in _tourRepository.GetAll())
            {
                if(IsConditionValid(tour, country, city, language, numberOfPeople, duration))
                {
                    tours.Add(tour);
                }
            }
            return tours;
        }


  /*      public Tour SaveCascadeImages(Tour tour)
        {
            return _tourRepository.SaveCascadeImages(tour);
        }
        public Tour SaveCascadeTourPoints(Tour tour)
        {
            return _tourRepository.SaveCascadeTourPoints(tour);
        }*/

        public Tour SaveImagesTourPoints(Tour tour) {

            return _tourRepository.SaveImagesTourPoints(tour);
        }
    }
}
