using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class ComplexTourRequestService
    {
        private IComplexTourRequestRepository _tourRequestRepository;
        public ComplexTourRequestService()
        {
            _tourRequestRepository = Injector.Injector.CreateInstance<IComplexTourRequestRepository>();
        }

        public List<ComplexTourRequest> GetAll()
        {
            return _tourRequestRepository.GetAll();
        }

        public ComplexTourRequest Get(int id)
        {
            return _tourRequestRepository.Get(id);
        }

        public ComplexTourRequest Save(ComplexTourRequest request)
        {
            return _tourRequestRepository.Save(request);
        }

        public ComplexTourRequest Update(ComplexTourRequest request)
        {
            return _tourRequestRepository.Update(request);
        }

        public void Delete(ComplexTourRequest request)
        {
            _tourRequestRepository.Delete(request);
        }

        public int NextId()
        {
            return _tourRequestRepository.NextId();
        }

        public List<ComplexTourRequest> GetAllComplexTourRequestsForUser(int userId)
        {
            List<ComplexTourRequest> myComplexRequests = new List<ComplexTourRequest>();
            var allComplexRequests = _tourRequestRepository.GetAll();

            for (int i = 0; i < allComplexRequests.Count(); i++)
            {
                var request = allComplexRequests.ElementAt(i);
                if (request.Guest.Id == userId)
                {
                    /*if ((request.SimpleTourRequests[0].Start - DateTime.Today).TotalDays <= 2 && request.Status == RequestStatusType.Standby)
                    {
                        request.Status = (RequestStatusType)Enum.Parse(typeof(RequestStatusType), "Declined");
                        _tourRequestRepository.Update(request);
                    }*/
                    myComplexRequests.Add(request);
                }
            }

            return myComplexRequests;
        }
    }
}
