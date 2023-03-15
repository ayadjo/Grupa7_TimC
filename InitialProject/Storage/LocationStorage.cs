using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Storage
{
    class LocationStorage
    {
        private const string StoragePath = "../../../Resources/Data/locations.csv";

        private readonly Serializer<Location> _serializer;


        public LocationStorage()
        {
            _serializer = new Serializer<Location>();
        }

        public List<Location> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Location> locations)
        {
            _serializer.ToCSV(StoragePath, locations);
        }
    }
}
