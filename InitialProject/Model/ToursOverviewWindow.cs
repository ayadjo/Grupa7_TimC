using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    class ToursOverviewWindow
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }
        public int NumberOfPeople { get; set; }

        public ToursOverviewWindow() { }

        public ToursOverviewWindow(int id, Location location, int duration, string language, int numberOfPeople)
        {
            Duration = duration;
            Language = language;
            NumberOfPeople = numberOfPeople;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {   Id.ToString(),
                Location.Id.ToString(),
                Duration.ToString(),
                Language,
                NumberOfPeople.ToString()

            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Location = new Location() { Id = Convert.ToInt32(values[2]) };
            Duration = Convert.ToInt32(values[3]);
            Language = values[4];
            NumberOfPeople = Convert.ToInt32(values[5]);
        }
    }
}
