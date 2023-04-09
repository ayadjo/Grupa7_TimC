using InitialProject.Domain.Models;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repositories
{
    public class TourPointRepository
    {

        private const string FilePath = "../../../Resources/Data/tourPoints.csv";

        private static TourPointRepository instance = null;

        private readonly Serializer<TourPoint> _serializer;

        private List<TourPoint> _tourPoints;

        private TourPointRepository()
        {

            _serializer = new Serializer<TourPoint>();
            _tourPoints = _serializer.FromCSV(FilePath);
        }

        public static TourPointRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new TourPointRepository();
            }
            return instance;
        }

        public void BindTourPointTour()
        {
            foreach (TourPoint tourPoint in _tourPoints)
            {
                int tourId = tourPoint.Tour.Id;
                Tour tour = TourRepository.GetInstance().Get(tourId);
                if (tour != null)
                {
                    tourPoint.Tour = tour;
                    tour.TourPoints.Add(tourPoint);
                }
                else
                {
                    Console.WriteLine("Error in tourPointTour binding");
                }
            }
        }
        public TourPoint Save(TourPoint tourPoint)
        {
            tourPoint.Id = NextId();
            //_tourPoints = _serializer.FromCSV(FilePath);
            _tourPoints.Add(tourPoint);
            _serializer.ToCSV(FilePath, _tourPoints);
            return tourPoint;

        }

        public int NextId()
        {
            //_tourPoints = _serializer.FromCSV(FilePath);
            if (_tourPoints.Count < 1)
            {
                return 1;
            }
            return _tourPoints.Max(tp => tp.Id) + 1;
        }

        public void Delete(TourPoint tourPoint)
        {
            //_tourPoints = _serializer.FromCSV(FilePath);
            TourPoint founded = _tourPoints.Find(tp => tp.Id == tourPoint.Id);
            _tourPoints.Remove(founded);
            _serializer.ToCSV(FilePath, _tourPoints);
        }

        public TourPoint Update(TourPoint tourPoint)
        {
            //_tourPoints = _serializer.FromCSV(FilePath);
            TourPoint current = _tourPoints.Find(tp => tp.Id == tourPoint.Id);
            int index = _tourPoints.IndexOf(current);
            _tourPoints.Remove(current);
            _tourPoints.Insert(index, tourPoint);
            _serializer.ToCSV(FilePath, _tourPoints);
            return tourPoint;
        }

        public List<TourPoint> GetAll()
        {

            return _tourPoints;

        }


        public TourPoint Get(int id)
        {

            return _tourPoints.Find(x => x.Id == id);

        }

        public List<TourPoint> GetByTour(int tourId)
        {
           // _tourPoints = _serializer.FromCSV(FilePath);
            return _tourPoints.FindAll(t => t.Tour.Id == tourId);
        }

    }
}
