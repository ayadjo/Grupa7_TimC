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
        public int Cleanliness { get; set; }
        public int Behaviour { get; set; }
        public string Comment { get; set; }

        public AccommodationReservation() { }
        public AccommodationReservation(User guest, Accommodation accommodation, int cleanliness, int behaviour, string comment)
        {
            Guest = guest;
            Accommodation = accommodation;
            Cleanliness = cleanliness;
            Behaviour = behaviour;
            Comment = comment;
        }

        string[] ISerializable.ToCSV()
        {
            string[] csvValues =
            {   Id.ToString(),
                Guest.Id.ToString(),
                Accommodation.Id.ToString(),
                Start.ToString(), //new class 
                End.ToString(),
                Cleanliness.ToString(),
                Behaviour.ToString(),
                Comment
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
            Cleanliness = Convert.ToInt32(values[5]);
            Behaviour = Convert.ToInt32(values[6]);
            Comment = values[7];
        }
    }
}
