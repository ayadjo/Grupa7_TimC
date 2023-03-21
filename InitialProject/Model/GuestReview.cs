using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class GuestReview : ISerializable
    {
        public int Id { get; set; }
        public AccommodationReservation Reservation { get; set; }
        public int Cleanliness { get; set; }
        public int Behaviour { get; set; }
        public string Comment { get; set; }

        public GuestReview() { }
        public GuestReview(int id, AccommodationReservation reservation, int cleanliness, int behaviour, string comment)
        {
            Id = id;
            Reservation = reservation;
            Cleanliness = cleanliness;
            Behaviour = behaviour;
            Comment = comment;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {   Id.ToString(),
                Reservation.Id.ToString(),
                Cleanliness.ToString(),
                Behaviour.ToString(),
                Comment
            };
            return csvValues;
            
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Reservation = new AccommodationReservation() { Id = Convert.ToInt32(values[1]) };
            Cleanliness = Convert.ToInt32(values[2]);
            Behaviour = Convert.ToInt32(values[3]);
            Comment = values[4];
        }
    }
}
