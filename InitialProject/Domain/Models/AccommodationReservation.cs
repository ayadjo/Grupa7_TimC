using InitialProject.Enumerations;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.Models
{
    public class AccommodationReservation : ISerializable
    {
        public int Id { get; set; }
        public User Guest { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public GuestReview Review { get; set; }

        public AccommodationReservation()
        {

        }

        public AccommodationReservation(int id, Accommodation accommodation, User guest, DateTime start, DateTime end, GuestReview guestReview)
        {
            Id = id;
            Accommodation = accommodation;
            Guest = guest;
            Start = start;
            End = end;
            Review = guestReview;
        }


        string[] ISerializable.ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Accommodation.Id.ToString(),
                Guest.Id.ToString(),
                Start.ToString(),
                End.ToString(),
                Review.Id.ToString()
            };
            return csvValues;
        }

        void ISerializable.FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Accommodation = new Accommodation() { Id = Convert.ToInt32(values[1]) };
            Guest = new User() { Id = Convert.ToInt32(values[2]) };
            Start = Convert.ToDateTime(values[3]);
            End = Convert.ToDateTime(values[4]);
            Review = new GuestReview() { Id = Convert.ToInt32(values[5]) };
        }
    }
}
