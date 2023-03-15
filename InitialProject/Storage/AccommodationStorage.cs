using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Storage
{
    class AccommodationStorage
    {
        private const string StoragePath = "../../../Resources/Data/accommodations.csv";

        private readonly Serializer<Accommodation> _serializer;


        public AccommodationStorage()
        {
            _serializer = new Serializer<Accommodation>();
        }

        public List<Accommodation> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Accommodation> accommodations)
        {
            _serializer.ToCSV(StoragePath, accommodations);
        }
    }
}
