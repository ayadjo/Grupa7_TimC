using InitialProject.Model;
using InitialProject.Observser;
using InitialProject.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    class LocationRepository : ISubject
    {
        private readonly List<IObserver> _observers;

        private readonly LocationStorage _storage;
        private readonly List<Location> _locations;

        public LocationRepository()
        {
            _storage = new LocationStorage();
            _locations = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            return _locations.Max(l => l.Id) + 1;
        }

        public List<Location> GetAll()
        {
            return _locations;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
