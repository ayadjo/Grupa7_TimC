using InitialProject.Enumerations;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class AccommodationReservation : ISerializable
    {
        public int Id { get; set; }
        public User Guest { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
   
        public GuestReview Review { get; set; }

        public AccommodationReservation() { }
        public AccommodationReservation(int id, User guest, Accommodation accommodation, DateTime start, DateTime end,GuestReview review)
        {
            Id = id; 
            Guest = guest;
            Accommodation = accommodation;
            Start = start;
            End = end;
            Review = review;
        }

        string[] ISerializable.ToCSV()
        {
            string[] csvValues =
            {   Id.ToString(),
                Guest.Id.ToString(),
                Accommodation.Id.ToString(),
                Start.ToString(),
                End.ToString(),
                Review.Id.ToString(),
            };
            return csvValues;
        }

        void ISerializable.FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Guest = new User() { Id = Convert.ToInt32(values[1]) };
            Accommodation = new Accommodation() { Id = Convert.ToInt32(values[2]) };
            Start = DateTime.Parse(values[3]);
            End = DateTime.Parse(values[4]);
            Review = new GuestReview() { Id = Convert.ToInt32(values[5]) };
        }
    }
}
