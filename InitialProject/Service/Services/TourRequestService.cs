using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Enumerations;
using InitialProject.Repositories;
using InitialProject.WPF.Views;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InitialProject.Service.Services
{
    public class TourRequestService
    {
        private ITourRequestRepository _tourRequestRepository;
        private TourEventService _tourEventService;
        private LocationService _locationService;
        public TourRequestService()
        {
            _tourRequestRepository = Injector.Injector.CreateInstance<ITourRequestRepository>();
            _tourEventService = new TourEventService();
        }

        public List<TourRequest> GetAll()
        {
            return _tourRequestRepository.GetAll();
        }

        public TourRequest Get(int id)
        {
            return _tourRequestRepository.Get(id);
        }

        public TourRequest Save(TourRequest request)
        {
            return _tourRequestRepository.Save(request);
        }

        public TourRequest Update(TourRequest request)
        {
            return _tourRequestRepository.Update(request);
        }

        public void Delete(TourRequest request)
        {
            _tourRequestRepository.Delete(request);
        }

        public List<TourRequest> GetAllTourRequestsForUser(int userId)
        {
            List<TourRequest> myRequests = new List<TourRequest>();
            var allRequests = _tourRequestRepository.GetAll();

            for (int i = 0; i < allRequests.Count(); i++)
            {
                var request = allRequests.ElementAt(i);
                if (request.Guest.Id == userId)
                {
                    if ((request.Start - DateTime.Today).TotalDays <= 2 && request.Status == RequestStatusType.Standby)
                    {
                        request.Status = (RequestStatusType)Enum.Parse(typeof(RequestStatusType), "Declined");
                        _tourRequestRepository.Update(request);
                    }
                    myRequests.Add(request);
                }
            }

            return myRequests;
        }

        public List<TourRequest> GetAllTourRequests()
        {

            List<TourRequest> tourRequests = new List<TourRequest>();

            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                if (tourRequest.Status == RequestStatusType.Standby && tourRequest.End.Date > DateTime.Now)
                {
                    tourRequests.Add(tourRequest);
                }
            }
            return tourRequests;

        }
        public List<int> YearsOfTourRequests(int guestId)
        {
            List<int> years = new List<int>();
            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                if (tourRequest.Guest.Id == guestId)
                {
                    years.Add(tourRequest.Start.Year);
                }
            }
            return years.Distinct().ToList();
        }

        public TourRequestPercentageDto GetPercentageOfTourRequest(int userId)
        {
            int acceptedRequests = 0;
            int rejectedRequests = 0;
            int numberOfPeopleInAcceptedRequests = 0;

            TourRequestPercentageDto tourRequestPercentage = new TourRequestPercentageDto(0, 0, 0);

            foreach (TourRequest tourRequest in GetAllTourRequestsForUser(userId))
            {
                if (tourRequest.Status == RequestStatusType.Approved)
                {
                    acceptedRequests += 1;
                    numberOfPeopleInAcceptedRequests += tourRequest.MaxGuests;
                }
                else if (tourRequest.Status == RequestStatusType.Declined)
                {
                    rejectedRequests += 1;
                }
            }

            CalculateRequestPercentage(tourRequestPercentage, acceptedRequests, rejectedRequests, numberOfPeopleInAcceptedRequests);

            return tourRequestPercentage;
        }

        public TourRequestPercentageDto GetPercentageOfTourRequestForYear(int userId, int year)
        {
            int acceptedRequests = 0;
            int rejectedRequests = 0;
            int numberOfPeopleInAcceptedRequests = 0;

            TourRequestPercentageDto tourRequestPercentage = new TourRequestPercentageDto(0, 0, 0);

            foreach (TourRequest tourRequest in GetAllTourRequestsForUser(userId))
            {
                if (tourRequest.Start.Year == year)
                {
                    if (tourRequest.Status == RequestStatusType.Approved)
                    {
                        acceptedRequests += 1;
                        numberOfPeopleInAcceptedRequests += tourRequest.MaxGuests;
                    }
                    else if (tourRequest.Status == RequestStatusType.Declined)
                    {
                        rejectedRequests += 1;
                    }
                }

            }

            CalculateRequestPercentage(tourRequestPercentage, acceptedRequests, rejectedRequests, numberOfPeopleInAcceptedRequests);

            return tourRequestPercentage;
        }

        private void CalculateRequestPercentage(TourRequestPercentageDto tourRequestPercentage, int acceptedRequests, int rejectedRequests, int numberOfPeopleInAcceptedRequests)
        {
            double totalRequests = acceptedRequests + rejectedRequests;

            if (totalRequests > 0)
            {
                double acceptedRequestsPercentage = (acceptedRequests * 100.0) / totalRequests;
                double rejectedRequestsPercentage = (rejectedRequests * 100.0) / totalRequests;
                tourRequestPercentage.PercentageOfAcceptedRequests = (int)Math.Round(acceptedRequestsPercentage);
                tourRequestPercentage.PercentageOfRejectedRequests = (int)Math.Round(rejectedRequestsPercentage);
                tourRequestPercentage.AverageNumberOfPeopleInAcceptedRequests = numberOfPeopleInAcceptedRequests / acceptedRequests;
            }
        }



        private bool IsConditionValid(TourRequest tourRequest, string country, string city, string language, int maxGuests, DateTime start, DateTime end)
        {
            bool retVal = tourRequest.Location.Country.Contains(country, StringComparison.OrdinalIgnoreCase) && tourRequest.Location.City.Contains(city, StringComparison.OrdinalIgnoreCase) && tourRequest.Language.Contains(language, StringComparison.OrdinalIgnoreCase);

            if (maxGuests != null)
            {
                int maxGuestsNum = Convert.ToInt32(maxGuests);
                retVal = retVal && tourRequest.MaxGuests >= maxGuestsNum;
            }
            retVal = retVal && start.Date <= tourRequest.Start.Date && end.Date >= tourRequest.End.Date;

            return retVal;

        }

        public List<TourRequest> SearchTourRequests(string country, string city, string language, int maxGuests, DateTime start, DateTime end)
        {
            try
            {
                List<TourRequest> tourRequests = SearchTourRequestsLogic(country, city, language, maxGuests, start, end);
                return tourRequests;
            }
            catch (Exception e)
            {
                return new List<TourRequest>();
            }
        }

        private List<TourRequest> SearchTourRequestsLogic(string country, string city, string language, int maxGuests, DateTime start, DateTime end)
        {
            List<TourRequest> tourRequests = new List<TourRequest>();

            foreach (TourRequest tourRequest in GetAllTourRequests())
            {
                if (IsConditionValid(tourRequest, country, city, language, maxGuests, start, end))
                {
                    tourRequests.Add(tourRequest);
                }
            }
            return tourRequests;
        }





        private void AddYearToStatisticsForLanguage(List<TourRequestsByYearDto> statistics, TourRequest tourRequest)
        {
            TourRequestsByYearDto byYearForLanguage = null;
            foreach (TourRequestsByYearDto tourRequestByYearForLanguage in statistics)
            {
                if (tourRequestByYearForLanguage.Year == tourRequest.Start.Year)
                {
                    byYearForLanguage = tourRequestByYearForLanguage;
                    break;
                }
            }
            if (byYearForLanguage == null)
            {
                byYearForLanguage = new TourRequestsByYearDto(tourRequest.Start.Year, 1);
                statistics.Add(byYearForLanguage);

            }
            else
            {
                byYearForLanguage.TourRequestsNum++;
            }
        }

        private void AddYearToStatisticsForLocation(List<TourRequestsByYearDto> statistics, TourRequest tourRequest)
        {
            TourRequestsByYearDto byYearForLocation = null;
            foreach (TourRequestsByYearDto tourRequestByYearForLocation in statistics)
            {
                if (tourRequestByYearForLocation.Year == tourRequest.Start.Year)
                {
                    byYearForLocation = tourRequestByYearForLocation;
                    break;
                }
            }
            if (byYearForLocation == null)
            {
                byYearForLocation = new TourRequestsByYearDto(tourRequest.Start.Year, 1);
                statistics.Add(byYearForLocation);

            }
            else
            {
                byYearForLocation.TourRequestsNum++;
            }
        }

        public List<TourRequestsByYearDto> GetStatisticsForLanguage(string language)
        {
            List<TourRequestsByYearDto> statistics = new List<TourRequestsByYearDto>();

            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                if (tourRequest.Language == language)
                {
                    AddYearToStatisticsForLanguage(statistics, tourRequest);
                }
            }

            return statistics;
        }

        public List<TourRequestsByYearDto> GetStatisticsForLocation(string country, string city)
        {
            List<TourRequestsByYearDto> statistics = new List<TourRequestsByYearDto>();

            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                if (tourRequest.Location.Country == country && tourRequest.Location.City == city)
                {
                    AddYearToStatisticsForLocation(statistics, tourRequest);
                }
            }

            return statistics;
        }
        private void AddMonthToStatisticsForLanguage(List<TourRequestsByMonthDto> statistics, TourRequest tourRequest)
        {
            TourRequestsByMonthDto byMonthForLanguage = null;
            foreach (TourRequestsByMonthDto tourRequestByMonthForLanguage in statistics)
            {
                if (tourRequestByMonthForLanguage.Month == tourRequest.Start.Month)
                {
                    byMonthForLanguage = tourRequestByMonthForLanguage;
                    break;
                }
            }
            if (byMonthForLanguage == null)
            {
                byMonthForLanguage = new TourRequestsByMonthDto(tourRequest.Start.Month, 1);
                statistics.Add(byMonthForLanguage);

            }
            else
            {
                byMonthForLanguage.RequestsNum++;
            }
        }

        private void AddMonthToStatisticsForLocation(List<TourRequestsByMonthDto> statistics, TourRequest tourRequest)
        {
            TourRequestsByMonthDto byMonthForLocation = null;
            foreach (TourRequestsByMonthDto tourRequestByMonthForLocation in statistics)
            {
                if (tourRequestByMonthForLocation.Month == tourRequest.Start.Month)
                {
                    byMonthForLocation = tourRequestByMonthForLocation;
                    break;
                }
            }
            if (byMonthForLocation == null)
            {
                byMonthForLocation = new TourRequestsByMonthDto(tourRequest.Start.Month, 1);
                statistics.Add(byMonthForLocation);

            }
            else
            {
                byMonthForLocation.RequestsNum++;
            }
        }

        public List<TourRequestsByMonthDto> GetStatisticsForLanguageMonts(string language, int year)
        {
            List<TourRequestsByMonthDto> statistics = new List<TourRequestsByMonthDto>();

            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                if (tourRequest.Language == language && tourRequest.Start.Year == year)
                {
                    AddMonthToStatisticsForLanguage(statistics, tourRequest);
                }
            }

            return statistics;
        }

        public List<TourRequestsByMonthDto> GetStatisticsForLocationMonts(string country, string city, int year)
        {
            List<TourRequestsByMonthDto> statistics = new List<TourRequestsByMonthDto>();

            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                if (tourRequest.Location.Country == country && tourRequest.Location.City == city && tourRequest.Start.Year == year)
                {
                    AddMonthToStatisticsForLocation(statistics, tourRequest);
                }
            }

            return statistics;
        }

        public List<TourRequest> LoadTourRequestsInLastYear()
        {
            DateTime today = DateTime.Today;
            DateTime lastYear = today.AddYears(-1);
            List<TourRequest> tourRequests = new List<TourRequest>();

            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                if (tourRequest.End <= today && tourRequest.Start >= lastYear)
                {
                    tourRequests.Add(tourRequest);
                }

            }
            return tourRequests;
        }

      

        public BestLanguageDto AddLanguage(List<BestLanguageDto> bestLanguages, TourRequest request) { 

            BestLanguageDto language = null;
            

            foreach (BestLanguageDto bestLanguageDto in bestLanguages)
            {

                if ( request.Language == language.Language)
                {
                    language.Language = request.Language;
                    break;
                }
                if (language == null)
                {
                    language = new BestLanguageDto();
                    language.Language = request.Language;
                    bestLanguages.Add(language);
                }
                else
                {
                    language.NumberOfRequests++;
                }


            }

            return language;

        }

        public List<BestLanguageDto> GetAllLanguages()
        {
            List<BestLanguageDto> bestLanguageDtos = new List<BestLanguageDto>();
            List<TourRequest> requests = LoadTourRequestsInLastYear();

            foreach (TourRequest request in requests)
            {
                AddLanguage(bestLanguageDtos, request);
            }


            return bestLanguageDtos;

        }



       /* public string GetBestLanguage()
        {
            List<BestLanguageDto> bestLanguageDtos = GetAllLanguages();
            List<TourRequest> requests = LoadTourRequestsInLastYear();

            foreach (TourRequest request in requests)
            {
                AddLanguage(bestLanguageDtos, request);
            }

            int max = bestLanguageDtos.Max(i => i.NumberOfRequests);
            BestLanguageDto bestStatistic = bestLanguageDtos.First(x => x.NumberOfRequests == max);

            return bestStatistic.Language;

        }*/
       
        public void HandleTourRequest(TourRequest request, DateTime date)
        {
            if (_tourEventService.IsGuideFree(SignInForm.LoggedUser.Id, date))
            {
                request.Status = RequestStatusType.Approved;
                _tourRequestRepository.Update(request);
                MessageBox.Show("Uspesno ste zakazali turu!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }


        /*public Location FindMostWanteddLocation(ObservableCollection<TourRequest> requests)
        {
            Dictionary<int, int> locationCounts = new Dictionary<int, int>();

            foreach (TourRequest request in requests)
            {
                
                    int locationId = request.Location.Id;

                    
                    Location location = _locationService.Get(locationId);

                    if (location != null)
                    {
                        if (locationCounts.ContainsKey(locationId))
                        {
                            locationCounts[locationId]++;
                        }
                        else
                        {
                            locationCounts[locationId] = 1;
                        }
                    }
                
            }

            int mostRequestedId = 0;
            int maxCount = 0;

            foreach (KeyValuePair<int, int> kvp in locationCounts)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mostRequestedId = kvp.Key;
                }
            }

            
            Location mostRequestedLocation = _locationService.Get(mostRequestedId);
            

            return mostRequestedLocation;
        }*/

        /*public string FindRequestNumberForMostWantedLanguage()
        {
            string mostWantedLanguage = Languages.ElementAt(0);
            int BestTourRequestNum = 0;

            List<TourRequest> tourRequestsInLastYear = _tourRequestService.LoadTourRequestsInLastYear();
            List<TourRequestsByYearDto> tourRequestsByYear = new List<TourRequestsByYearDto>();

            foreach (string language in Languages)
            {
                tourRequestsByYear = _tourRequestService.GetStatisticsForLanguage(language);
                foreach (TourRequestsByYearDto tourRequestByYear in tourRequestsByYear)
                {
                    if (tourRequestByYear.TourRequestsNum > BestTourRequestNum)
                    {
                        BestTourRequestNum = tourRequestByYear.TourRequestsNum;

                    }
                }





            }


            return mostWantedLanguage;

        }*/
    }
}
