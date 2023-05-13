using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Enumerations;
using InitialProject.Repositories;
using InitialProject.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class TourRequestService
    {
        private ITourRequestRepository _tourRequestRepository;
        public TourRequestService()
        {
            _tourRequestRepository = Injector.Injector.CreateInstance<ITourRequestRepository>();
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
                    if ((request.Start - DateTime.Today).TotalDays <= 2)
                    {
                        request.Status = (RequestStatusType)Enum.Parse(typeof(RequestStatusType), "Declined");
                        _tourRequestRepository.Update(request);
                    }
                    myRequests.Add(request);
                }
            }

            return myRequests;
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

        public TourRequestPercentageDto GetPercentageOfTourRequest(int userId, int year = -1)
        {
            int acceptedRequests = 0;
            int rejectedRequests = 0;

            TourRequestPercentageDto tourRequestPercentage = new TourRequestPercentageDto(0, 0);

            foreach (TourRequest tourRequest in GetAllTourRequestsForUser(userId))
            {
                if (tourRequest.Status == RequestStatusType.Approved)
                {
                    acceptedRequests += 1;
                }
                else if(tourRequest.Status == RequestStatusType.Declined)
                {
                    rejectedRequests += 1;
                }
            }
            double acceptedRequestsPercentage = (acceptedRequests * 100.0) / (acceptedRequests + rejectedRequests);
            double rejectedRequestsPercentage = (rejectedRequests * 100.0) / (acceptedRequests + rejectedRequests);
            tourRequestPercentage.PercentageOfAcceptedRequests = (int)Math.Round(acceptedRequestsPercentage);
            tourRequestPercentage.PercentageOfRejectedRequests = (int)Math.Round(rejectedRequestsPercentage);

            return tourRequestPercentage;
        }
    }
}
