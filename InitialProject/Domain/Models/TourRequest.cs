using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;
using InitialProject.Enumerations;
using InitialProject.Serializer;

namespace InitialProject.Domain.Models
{
    public class TourRequest : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public Location Location { get; set; }
        public string Language { get; set; }
        public int MaxGuests { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public User Guest { get; set; }
        public RequestStatusType Status { get; set; }

        public TourRequest() { }

        public TourRequest(int id,string name, Location location, string language, int maxGuests, string description, DateTime start, DateTime end, User guest, RequestStatusType status)
        {

            Id = id;
            Name = name;
            Location = location;
            Language = language;
            MaxGuests = maxGuests;
            Description = description;
            Start = start;
            End = end;
            Guest = guest;
            Status = status;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
               Id.ToString(),
               Name,
               Location.Id.ToString(),
               Language.ToString(),
               MaxGuests.ToString(),
               Description,   
               Start.ToString(),
               End.ToString(),
               Guest.Id.ToString(),
               Status.ToString()
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Location = new Location() { Id = Convert.ToInt32(values[2]) };
            Language = values[3];
            MaxGuests = Convert.ToInt32(values[4]);
            Description = values[5];
            Start = Convert.ToDateTime(values[6]);
            End = Convert.ToDateTime(values[7]);
            Guest = new User() { Id = Convert.ToInt32(values[8]) };
            Status = (RequestStatusType)Enum.Parse(typeof(RequestStatusType), values[9]);
        }
    }
}
