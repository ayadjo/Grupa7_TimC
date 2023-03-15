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
    class AccommodationRepository : ISubject
    {
        private readonly List<IObserver> _observers;

        private readonly AccommodationStorage _storage;
        private readonly List<Accommodation> _accommodations;

        public AccommodationRepository()
        {
            _storage = new AccommodationStorage();
            _accommodations = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            return _accommodations.Max(s => s.Id) + 1;
        }

        public List<Accommodation> GetAll()
        {
            return _accommodations;
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
