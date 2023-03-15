using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Location : ISerializable
    {
        public int Id { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public Location() { }
        public Location(String state, String city)
        {
            State = state;
            City = city;
        }
        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), State, City };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            State = values[1];
            City = values[2];
        }
    }
}
