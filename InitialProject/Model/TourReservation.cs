using InitialProject.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InitialProject.Model
{
    public class TourReservation
    {
        public int Id { get; set; }

        public int NumberOfPeople { get; set; }

        public TourEvent TourEvent { get; set; }

        public User Guest { get; set; }

        public TourReservation()
        {
            
        }

        public TourReservation(int id, int numberOfPeople,TourEvent tourEvent, User guest)
        {
            Id = id;
            NumberOfPeople = numberOfPeople;
            TourEvent = tourEvent;
            Guest = guest;

        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {   
                Id.ToString(),
                NumberOfPeople.ToString(),
                TourEvent.Id.ToString(),
                Guest.Id.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            NumberOfPeople = Convert.ToInt32(values[1]);
            TourEvent = new TourEvent() { Id = Convert.ToInt32(values[2]) };
            Guest = new User() { Id = Convert.ToInt32(values[3]) };
        }
    }
}
