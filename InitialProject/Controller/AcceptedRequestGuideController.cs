using InitialProject.Domain.Models;
using InitialProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    public class AcceptedRequestGuideController
    {
        private readonly AcceptedRequestGuideService _acceptedRequestGuideService;

        public AcceptedRequestGuideController()
        {
            _acceptedRequestGuideService = new AcceptedRequestGuideService();
        }

        public List<AcceptedRequestGuide> GetAll()
        {
            return _acceptedRequestGuideService.GetAll();
        }

        public AcceptedRequestGuide Get(int id)
        {
            return _acceptedRequestGuideService.Get(id);
        }

        public AcceptedRequestGuide Save(AcceptedRequestGuide AcceptedRequestGuide)
        {

            return _acceptedRequestGuideService.Save(AcceptedRequestGuide);
        }

        public void Delete(AcceptedRequestGuide AcceptedRequestGuide)
        {

            _acceptedRequestGuideService.Delete(AcceptedRequestGuide);

        }

        public AcceptedRequestGuide Update(AcceptedRequestGuide AcceptedRequestGuide)
        {
            return _acceptedRequestGuideService.Update(AcceptedRequestGuide);
        }

    }
}
