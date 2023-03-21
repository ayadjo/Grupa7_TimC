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
        public int GuestId { get; set; }
        public Accommodation Accommodation { get; set; }
        public int AccommodationId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public GuestReview Review { get; set; }

        public AccommodationReservation()
        {

        }

        public AccommodationReservation(int id, int guestId, int accommodationId, DateTime start, DateTime end)
        {
            Id = id;
            GuestId = guestId;
            AccommodationId = accommodationId;
            Start = start;
            End = end;
        }


        string[] ISerializable.ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                AccommodationId.ToString(),
                GuestId.ToString(),
                Start.ToString(),
                End.ToString()
            };
            return csvValues;
        }

        void ISerializable.FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            AccommodationId = Convert.ToInt32(values[1]);
            GuestId = Convert.ToInt32(values[2]);
            Start = Convert.ToDateTime(values[3]);
            End = Convert.ToDateTime(values[4]);

        }
    }
}
