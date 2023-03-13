using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    class ToursOverviewRepository
    {
        private const string FilePath = "../../../Resources/Data/tours.csv";

        private readonly Serializer<ToursOverviewWindow> _serializer;

        private List<ToursOverviewWindow> _tours;

        public ToursOverviewRepository()
        {
            _serializer = new Serializer<ToursOverviewWindow>();
            _tours = _serializer.FromCSV(FilePath);
        }
        public List<ToursOverviewWindow> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
        public ToursOverviewWindow Get(int id)
        {
            return _tours.Find(t => t.Id == id);
        }
        public ToursOverviewWindow Save(ToursOverviewWindow tours)
        {
            tours.Id = NextId();
            _tours = _serializer.FromCSV(FilePath);
            _tours.Add(tours);
            _serializer.ToCSV(FilePath, _tours);
            return tours;
        }
        public int NextId()
        {
            _tours = _serializer.FromCSV(FilePath);
            if (_tours.Count < 1)
            {
                return 1;
            }
            return _tours.Max(t => t.Id) + 1;
        }
        public void Delete(ToursOverviewWindow tours)
        {
            _tours = _serializer.FromCSV(FilePath);
            ToursOverviewWindow founded = _tours.Find(t => t.Id == tours.Id);
            _tours.Remove(founded);
            _serializer.ToCSV(FilePath, _tours);
        }

        public ToursOverviewWindow Update(ToursOverviewWindow tours)
        {
            _tours = _serializer.FromCSV(FilePath);
            ToursOverviewWindow current = _tours.Find(t => t.Id == tours.Id);
            int index = _tours.IndexOf(current);
            _tours.Remove(current);
            _tours.Insert(index, tours);       // keep ascending order of ids in file 
            _serializer.ToCSV(FilePath, _tours);
            return tours;
        }

        public List<ToursOverviewWindow> GetByGuest2(int guest2Id)
        {
            _tours = _serializer.FromCSV(FilePath);
            return _tours.FindAll(i => i.Guest2.Id == guest2Id);
        }
    }
}
