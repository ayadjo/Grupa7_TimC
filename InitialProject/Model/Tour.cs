using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialProject.Enumerations;
using InitialProject.Serializer;

namespace InitialProject.Model
{
    public class Tour : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public String Description { get; set; }
        public String Languages { get; set; }
        public int MaxGuests { get; set; }
        public int Duration { get; set; }

        public List<TourEvent> TourEvents { get; set; }
        public List<TourPoint> TourPoints { get; set; } 
        public List<Image> Images { get; set; }
        public User Guide { get; set; }


        public Tour() {

            TourPoints = new List<TourPoint>();
            TourEvents = new List<TourEvent>();
            Images = new List<Image>(); 

        }

        public Tour(String name, Location location, String description, String languages, int maxGuests, int duration, User guide) { 
        
            Name = name;    
            Location = location;    
            Description = description;  
            Languages = languages;  
            MaxGuests = maxGuests;
            Duration = duration;
            TourPoints = new List<TourPoint>(); 
            TourEvents= new List<TourEvent>();
            Images= new List<Image>();  
            Guide = guide;

        }

        public string[] ToCSV() {


            string[] csvValues =
           {  
               Id.ToString(),
               Name,
               Location.Id.ToString(),
               Description,
               Languages,
               MaxGuests.ToString(),   
               Duration.ToString(),
               Guide.Id.ToString()

           };
            
            return csvValues;

        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Location = new Location() { Id = Convert.ToInt32(values[2]) };
            Description = values[3];
            Languages = values[4];
            MaxGuests = Convert.ToInt32(values[5]); 
            Duration = Convert.ToInt32(values[6]);
            Guide = new User() { Id = Convert.ToInt32(values[7]) };

           
        }

    }
}
