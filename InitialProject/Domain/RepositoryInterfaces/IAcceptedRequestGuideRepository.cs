using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface IAcceptedRequestGuideRepository
    {
        AcceptedRequestGuide Get(int id);
        List<AcceptedRequestGuide> GetAll();

        AcceptedRequestGuide Save(AcceptedRequestGuide acceptedRequestGuide);

        void Delete(AcceptedRequestGuide acceptedRequestGuide);

        AcceptedRequestGuide Update(AcceptedRequestGuide acceptedRequestGuide);
    }
}
