using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class AcceptedRequestGuideService
    {
        private IAcceptedRequestGuideRepository _acceptedRequestGuideRepository;
        public AcceptedRequestGuideService()
        {
            _acceptedRequestGuideRepository = Injector.Injector.CreateInstance<IAcceptedRequestGuideRepository>();
        }

        public List<AcceptedRequestGuide> GetAll()
        {
            return _acceptedRequestGuideRepository.GetAll();
        }

        public AcceptedRequestGuide Get(int id)
        {
            return _acceptedRequestGuideRepository.Get(id);
        }

        public AcceptedRequestGuide Save(AcceptedRequestGuide request)
        {
            return _acceptedRequestGuideRepository.Save(request);
        }

        public AcceptedRequestGuide Update(AcceptedRequestGuide request)
        {
            return _acceptedRequestGuideRepository.Update(request);
        }

        public void Delete(AcceptedRequestGuide request)
        {
            _acceptedRequestGuideRepository.Delete(request);
        }
    }
}
