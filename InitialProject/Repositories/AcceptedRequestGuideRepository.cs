using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repositories
{
    public class AcceptedRequestGuideRepository : IAcceptedRequestGuideRepository
    {
        private const string FilePath = "../../../Resources/Data/acceptedRequestGuide.csv";

        private readonly Serializer<AcceptedRequestGuide> _serializer;

        private List<AcceptedRequestGuide> _acceptedRequestGuide;

        public AcceptedRequestGuideRepository()
        {
            _serializer = new Serializer<AcceptedRequestGuide>();
            _acceptedRequestGuide = _serializer.FromCSV(FilePath);
        }


        public void BindAcceptedRequestGuideUser()
        {
            foreach (AcceptedRequestGuide acceptedRequestGuide in _acceptedRequestGuide)
            {
                int userId = acceptedRequestGuide.Guide.Id;
                User user = UserRepository.GetInstance().Get(userId);
                if (user != null)
                {
                    acceptedRequestGuide.Guide = user;
                }
                else
                {
                    Console.WriteLine("Error in acceptedRequestGuideUser binding");
                }
            }
        }

       

        public List<AcceptedRequestGuide> GetAll()
        {
            return _acceptedRequestGuide;
        }
        public AcceptedRequestGuide Get(int id)
        {
            return _acceptedRequestGuide.Find(t => t.Id == id);
        }
        public AcceptedRequestGuide Save(AcceptedRequestGuide acceptedRequestGuide)
        {
            acceptedRequestGuide.Id = NextId();
            _acceptedRequestGuide.Add(acceptedRequestGuide);
            _serializer.ToCSV(FilePath, _acceptedRequestGuide);
            return acceptedRequestGuide;
        }
        public int NextId()
        {
            if (_acceptedRequestGuide.Count < 1)
            {
                return 1;
            }
            return _acceptedRequestGuide.Max(a => a.Id) + 1;
        }
        public void Delete(AcceptedRequestGuide acceptedRequestGuide)
        {
            AcceptedRequestGuide founded = _acceptedRequestGuide.Find(a => a.Id == acceptedRequestGuide.Id);
            _acceptedRequestGuide.Remove(founded);
            _serializer.ToCSV(FilePath, _acceptedRequestGuide);
        }

        public AcceptedRequestGuide Update(AcceptedRequestGuide acceptedRequestGuide)
        {
            AcceptedRequestGuide current = _acceptedRequestGuide.Find(a => a.Id == acceptedRequestGuide.Id);
            int index = _acceptedRequestGuide.IndexOf(current);
            _acceptedRequestGuide.Remove(current);
            _acceptedRequestGuide.Insert(index, acceptedRequestGuide);
            _serializer.ToCSV(FilePath, _acceptedRequestGuide);
            return acceptedRequestGuide;
        }

    }
}
