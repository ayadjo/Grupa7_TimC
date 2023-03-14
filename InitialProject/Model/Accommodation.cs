using InitialProject.Enumerations;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace InitialProject.Model
{
    public class Accommodation : InitialProject.Serializer.ISerializable
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Location Location { get; set; }
        public AccommodationType Type { get; set; }
        public int MaxGuests { get; set; }
        public int MinDaysForReservation { get; set; }
        public int CancelationPeriod { get; set; }
        public List<Image> Images { get; set; }
        public User Vlasnik { get; set; }

        public Accommodation() { 
            Images = new List<Image>();
        }

        public Accommodation(String name, Location location, AccommodationType type, int maxGuests, int minDaysForReservation, int cancelationPeriod, User vlasnik)
        {
            Name = name;
            Location = location;
            Type = type;
            MaxGuests = maxGuests;
            MinDaysForReservation = minDaysForReservation;
            CancelationPeriod = cancelationPeriod;
            Images = new List<Image>();
            Vlasnik = vlasnik;

        }

        public string[] ToCSV()
        {
            string[] csvValues = 
            {   Id.ToString(), 
                Name, 
                Location.Id.ToString(), 
                Type.ToString(), 
                MaxGuests.ToString(),
                MinDaysForReservation.ToString(),
                CancelationPeriod.ToString(),
                Vlasnik.Id.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Location = new Location() { Id = Convert.ToInt32(values[2]) };
            //nisam sigurna da li je dobro ovo za enumeraciju, ako neko zna kako neka ispravi
            if (Convert.ToInt32(values[3]) == 0)
            {
                Type = AccommodationType.apartment;
            }
            else if (Convert.ToInt32(values[3]) == 1)
            {
                Type = AccommodationType.house;
            }else
            {
                Type = AccommodationType.cottage;
            }
            MaxGuests = Convert.ToInt32(values[4]);
            MinDaysForReservation = Convert.ToInt32(values[5]);
            CancelationPeriod = Convert.ToInt32(values[6]);
            Vlasnik = new User() { Id = Convert.ToInt32(values[7]) };
        }

    }
}
