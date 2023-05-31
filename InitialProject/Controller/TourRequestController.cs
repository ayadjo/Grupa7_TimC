using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    public class TourRequestController
    {
        private readonly TourRequestService _tourRequestService;

        public TourRequestController()
        {
            _tourRequestService = new TourRequestService();
        }

        public List<TourRequest> GetAll()
        {
            return _tourRequestService.GetAll();
        }

        public TourRequest Get(int id)
        {
            return _tourRequestService.Get(id);
        }

        public TourRequest Save(TourRequest tourRequest)
        {

            return _tourRequestService.Save(tourRequest);
        }

        public void Delete(TourRequest tourRequest)
        {

            _tourRequestService.Delete(tourRequest);

        }

        public TourRequest Update(TourRequest tourRequest)
        {
            return _tourRequestService.Update(tourRequest);
        }

        public List<TourRequest> GetAllTourRequestsForUser(int userId)
        {
            return _tourRequestService.GetAllTourRequestsForUser(userId);
        }

        public List<TourRequest> GetAllTourRequests()
        {
            return _tourRequestService.GetAllTourRequests();   
        }

        public List<int> YearsOfTourRequests(int guestId)
        {
            return _tourRequestService.YearsOfTourRequests(guestId);
        }

        public TourRequestPercentageDto GetPercentageOfTourRequest(int userId)
        {
            return _tourRequestService.GetPercentageOfTourRequest(userId);
        }

        public TourRequestPercentageDto GetPercentageOfTourRequestForYear(int userId, int year)
        {
            return _tourRequestService.GetPercentageOfTourRequestForYear(userId, year);
        }

        public List<TourRequest> SearchTourRequests(string country, string city, string language, int maxGuests, DateTime start, DateTime end)
        {
            return _tourRequestService.SearchTourRequests(country,city,language,maxGuests,start,end);
        }

        public List<TourRequestsByMonthDto> GetStatisticsForLanguageMonts(string language, int year)
        {
            return _tourRequestService.GetStatisticsForLanguageMonts(language,year);
        }

        public List<TourRequestsByMonthDto> GetStatisticsForLocationMonts(string country, string city, int year)
        {
            return _tourRequestService.GetStatisticsForLocationMonts(country,city, year);
        }

        public List<TourRequestsByYearDto> GetStatisticsForLanguage(string language)
        {
            return _tourRequestService.GetStatisticsForLanguage(language);
        }

        public List<TourRequestsByYearDto> GetStatisticsForLocation(string country, string city)
        {
            return _tourRequestService.GetStatisticsForLocation(country, city);
        }

        public List<TourRequest> LoadTourRequestsInLastYear()
        {
            return _tourRequestService.LoadTourRequestsInLastYear();
        }

        public void HandleTourRequest(TourRequest request, DateTime date)
        {
             _tourRequestService.HandleTourRequest(request, date);
        }

       

        /*public Location FindMostWanteddLocation(ObservableCollection<TourRequest> requests)
        {
            return _tourRequestService.FindMostWanteddLocation(requests);
        }*/
    }
}
